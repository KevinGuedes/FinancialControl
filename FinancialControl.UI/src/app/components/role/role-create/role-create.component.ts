import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomSnackBarService } from 'src/app/components/message/custom-snack-bar/custom-snack-bar.service';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-role-create',
  templateUrl: './role-create.component.html',
  styleUrls: ['./role-create.component.css']
})
export class RoleCreateComponent implements OnInit {

  roleForm: FormGroup;
  invalidFields: string[] = [];

  constructor(
    private router: Router,
    private customSnackBarService: CustomSnackBarService,
    private roleService: RoleService
  ) { }

  ngOnInit(): void {
    this.roleForm = new FormGroup({
      name: new FormControl(null, [
        Validators.required,
        Validators.maxLength(50),
      ]),
      description: new FormControl(null, [
        Validators.required,
        Validators.maxLength(50),
      ]),
    });
  }

  saveNewRole(): void {
    const role = this.roleForm.value;
    this.roleService.insertRole(role).subscribe(
      (response) => {
        this.customSnackBarService.successMessage(response.message);
        this.router.navigate(['role']);
      },
      (error) => {
        this.invalidFields = [];
        if (error.status === 400) {
          for (let field in error.error.errors) {
            if (error.error.errors.hasOwnProperty(field)) {
              this.invalidFields.push(error.error.errors[field]);
            }
          }
        }
      }
    );
  }

  get formControl() {
    return this.roleForm.controls;
  }
}
