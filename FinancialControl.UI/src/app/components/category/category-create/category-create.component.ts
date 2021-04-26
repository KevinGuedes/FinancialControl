import { Component, OnInit } from '@angular/core';
import { TypeService } from 'src/app/services/type.service';
import { FormGroup, FormControl, Validators } from '@angular/forms'
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
  invalidFields: string[] = [];

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
      name: new FormControl(null, [Validators.required, Validators.maxLength(50)]),
      icon: new FormControl(null, [Validators.required, Validators.maxLength(15)]),
      typeId: new FormControl(0, [Validators.required, Validators.min(1), Validators.max(2)]),
    })
  }

  saveNewCategory(): void {
    const category = this.categoryForm.value;
    console.log(this.categoryForm.controls.name.errors)
    this.categoryService.insertCategory(category).subscribe(
      response => {
        this.customSnackBarService.successMessage(response.message);
        this.router.navigate(['category']);
      },
      error => {
        this.invalidFields = [];
        if (error.status === 400) {
          for (let field in error.error.errors) {
            if (error.error.errors.hasOwnProperty(field)) {
              this.invalidFields.push(error.error.errors[field])
            }
          }
        }
      })
  }

  get formControl() {
    return this.categoryForm.controls;
  }
}
