import { Component, OnInit } from '@angular/core';
import { TypeService } from 'src/app/services/type.service';
import { FormGroup, FormControl } from '@angular/forms'
import { Type } from 'src/app/models/type.model';
import { CategoryService } from 'src/app/services/category.service';
import { Router } from '@angular/router';
import { CustomSnackBarService } from '../../message/custom-snack-bar/custom-snack-bar.service';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
export class CategoryCreateComponent implements OnInit {

  categoryForm: FormGroup;
  types: Type[];
  isSearchCompleted: boolean = false;

  constructor(
    private typeService: TypeService,
    private categoryService: CategoryService,
    private router: Router,
    private customSnackBarService: CustomSnackBarService,
  ) { }

  ngOnInit(): void {
    this.typeService.getTypes().subscribe(types => {
      this.types = types;
      this.isSearchCompleted = true;
    })

    this.categoryForm = new FormGroup({
      name: new FormControl(null),
      icon: new FormControl(null),
      typeId: new FormControl(null),
    })
  }

  saveNewCategory(): void {
    const category = this.categoryForm.value;
    this.categoryService.insertCategory(category).subscribe(response => {
      this.customSnackBarService.successMessage(response.message);
      this.router.navigate(['category']);
    })
  }

  get property() {
    return this.categoryForm.controls;
  }
}
