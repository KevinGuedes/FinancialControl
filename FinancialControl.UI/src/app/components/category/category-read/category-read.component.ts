import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Category } from 'src/app/models/category.model';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { CustomSnackBarService } from '../../message/custom-snack-bar/custom-snack-bar.service';

@Component({
  selector: 'app-category-read',
  templateUrl: './category-read.component.html',
  styleUrls: ['./category-read.component.css']
})
export class CategoryReadComponent implements OnInit {

  dataSource: MatTableDataSource<Category>;
  displayedColumns = ['name', 'icon', 'type.name', 'actions']
  isSearchCompleted: boolean = false;
  filteredOptions: Observable<string[]>;
  options: string[];
  filterFormControl: FormControl = new FormControl();

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private categoryService: CategoryService,
    private customDialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.buildCategoryTable();
  }

  applyFilter(value: string): void {
    this.dataSource.filter = value.trim().toLowerCase();
  }

  openDeleteDialog(id: number, name: string): void {
    this.customDialog
      .open(DialogCategoryDeleteComponent, {
        data: {
          categoryId: id,
          categoryName: name
        }
      })
      .afterClosed()
      .subscribe(answer => {
        if (answer)
          this.buildCategoryTable();
      })
  }

  buildCategoryTable(): void {
    this.categoryService.getCategories().subscribe(categories => {
      this.options = categories.map(category => category.name);
      this.filteredOptions = this.filterFormControl.valueChanges
        .pipe(
          startWith(''),
          map(value => this._filter(value)),
        );

      this.dataSource = new MatTableDataSource(categories);
      this.dataSource.paginator = this.paginator;
      this.isSearchCompleted = true;
      this.dataSource.sort = this.sort;
      this.dataSource.sortingDataAccessor = (data, sortHeaderId: string) => {
        return this.getPropertyByPath(data, sortHeaderId);
      };
    })
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }

  private getPropertyByPath(obj: Object, pathString: string) {
    return pathString.split('.').reduce((o, i) => o[i], obj);
  }
}

@Component({
  selector: 'app-dialog-category-delete',
  templateUrl: './dialog-category-delete.component.html',
  styleUrls: ['./category-read.component.css']
})
export class DialogCategoryDeleteComponent {

  constructor(
    public dialogRef: MatDialogRef<DialogCategoryDeleteComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      categoryName: string,
      categoryId: number
    },
    private categoryService: CategoryService,
    private customSnackBarService: CustomSnackBarService
  ) { }

  deleteCategory(id: number) {
    this.categoryService.deleteCategory(id).subscribe(response => {
      this.customSnackBarService.warningMessage(response.message);
      this.close(true);
    })
  }

  close(answer: boolean): void {
    this.dialogRef.close(answer);
  }
}
