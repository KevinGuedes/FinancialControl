import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Category } from 'src/app/models/category.model';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
  selector: 'app-category-read',
  templateUrl: './category-read.component.html',
  styleUrls: ['./category-read.component.css']
})
export class CategoryReadComponent implements OnInit {

  dataSource: MatTableDataSource<Category>;
  displayedColumns = ['name', 'icon', 'type', 'actions']
  isSearchCompleted: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private categoryService: CategoryService,
    private customDialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.buildCategoryTable();
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  openDeleteDialog(id: number, name: string): void {
    this.customDialog
      .open(DeleteDialogComponent, {
        data: {
          categroyId: id,
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
      this.dataSource = new MatTableDataSource(categories);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.isSearchCompleted = true;
    })
  }
}

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html'
})
export class DeleteDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<DeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      categoryName: string,
      categoryId: number
    },
    private categoryService: CategoryService
  ) { }

  deleteCategory(id: number) {
    console.log(id)
    this.categoryService.deleteCategory(id).subscribe(category => {
      this.close(true);
    })
  }

  close(answer: boolean): void {
    this.dialogRef.close(answer);
  }
}
