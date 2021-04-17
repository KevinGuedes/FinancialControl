import { Component, OnInit } from '@angular/core';
import { TypeService } from 'src/app/services/type.service';
import { FormGroup, FormControl } from '@angular/forms'
import { Type } from 'src/app/models/type.model';

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
    private typeService: TypeService
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

  get property() {
    return this.categoryForm.controls;
  }
}
