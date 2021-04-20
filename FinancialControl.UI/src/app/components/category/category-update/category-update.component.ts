import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/models/category.model';
import { Type } from 'src/app/models/type.model';
import { CategoryService } from 'src/app/services/category.service';
import { TypeService } from 'src/app/services/type.service';

@Component({
  selector: 'app-category-update',
  templateUrl: './category-update.component.html',
  styleUrls: ['./category-update.component.css']
})
export class CategoryUpdateComponent implements OnInit {

  categoryName: string;
  category: Category;
  types: Type[];
  categoryForm: FormGroup;
  isSearchCompleted: boolean = false;

  constructor(
    private categoryService: CategoryService,
    private typeService: TypeService,
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.params.id;
    this.typeService.getTypes().subscribe(types => {
      this.types = types
    })

    this.categoryService.getCategoryById(id).subscribe(category => {
      this.category = category;
      this.categoryName = category.name;
      this.isSearchCompleted = true;

      this.categoryForm = new FormGroup({
        id: new FormControl(category.id),
        name: new FormControl(category.name),
        icon: new FormControl(category.icon),
        typeId: new FormControl(category.typeId),
      })
    })
  }

  get property() {
    return this.categoryForm.controls;
  }
}
