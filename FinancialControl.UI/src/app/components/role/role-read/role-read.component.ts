import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { Role } from 'src/app/models/role.model';
import { RoleService } from 'src/app/services/role.service';
import { CustomSnackBarService } from '../../message/custom-snack-bar/custom-snack-bar.service';

@Component({
  selector: 'app-role-read',
  templateUrl: './role-read.component.html',
  styleUrls: ['./role-read.component.css']
})
export class RoleReadComponent implements OnInit {

  dataSource: MatTableDataSource<Role>;
  displayedColumns = ['name', 'description', 'actions']
  isSearchCompleted: boolean = false;
  filteredOptions: Observable<string[]>;
  options: string[];
  filterFormControl: FormControl = new FormControl();

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  constructor(
    private roleService: RoleService,
    private customDialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.buildRoleTable();
  }

  applyFilter(value: string): void {
    this.dataSource.filter = value.trim().toLowerCase();
  }

  openDeleteDialog(id: number, name: string): void {
    this.customDialog
      .open(DialogRoleDeleteComponent, {
        data: {
          roleId: id,
          roleName: name
        }
      })
      .afterClosed()
      .subscribe(answer => {
        if (answer)
          this.buildRoleTable();
      })
  }

  buildRoleTable(): void {
    this.roleService.getRoles().subscribe(roles => {
      this.options = roles.map(role => role.name);
      this.filteredOptions = this.filterFormControl.valueChanges
        .pipe(
          startWith(''),
          map(value => this._filter(value)),
        );

      this.dataSource = new MatTableDataSource(roles);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.isSearchCompleted = true;
    })
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }
}

@Component({
  selector: 'app-dialog-role-delete',
  templateUrl: './dialog-role-delete.component.html',
  styleUrls: ['./role-read.component.css']
})
export class DialogRoleDeleteComponent {

  constructor(
    public dialogRef: MatDialogRef<DialogRoleDeleteComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      roleName: string,
      roleId: string
    },
    private roleService: RoleService,
    private customSnackBarService: CustomSnackBarService
  ) { }

  deleteRole(id: string) {
    this.roleService.deleteRole(id).subscribe(response => {
      this.customSnackBarService.warningMessage(response.message);
      this.close(true);
    })
  }

  close(answer: boolean): void {
    this.dialogRef.close(answer);
  }
}
