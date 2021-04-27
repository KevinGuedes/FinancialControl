import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-role-read',
  templateUrl: './role-read.component.html',
  styleUrls: ['./role-read.component.css']
})
export class RoleReadComponent implements OnInit {

  dataSource: MatTableDataSource<Function>;
  displayedColumns = ['name', 'icon', 'type', 'actions']
  isSearchCompleted: boolean = false;
  filteredOptions: Observable<string[]>;
  options: string[];
  filterFormControl: FormControl = new FormControl();

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  constructor(
    private RoleService: RoleService
  ) { }

  ngOnInit(): void {
  }
}
