import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Role } from 'src/app/models/role.model';
import { RoleService } from 'src/app/services/role.service';
import { CustomSnackBarService } from '../../message/custom-snack-bar/custom-snack-bar.service';

@Component({
  selector: 'app-role-update',
  templateUrl: './role-update.component.html',
  styleUrls: ['./role-update.component.css']
})
export class RoleUpdateComponent implements OnInit {

  roleId: string;
  role: Role;
  roleForm: FormGroup;
  isSearchCompleted: boolean = false;
  invalidFields: string[] = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private roleService: RoleService,
    private customSnackBarService: CustomSnackBarService
  ) { }

  ngOnInit(): void {
    this.roleId = this.route.snapshot.params.id;

    this.roleService.getRoleById(this.roleId).subscribe(role => {
      this.role = role;

      this.roleForm = new FormGroup({
        id: new FormControl(role.id, [
          Validators.required
        ]),
        name: new FormControl(role.name, [
          Validators.required,
          Validators.maxLength(50),
        ]),
        description: new FormControl(role.description, [
          Validators.required,
          Validators.maxLength(50),
        ]),
      });

      this.isSearchCompleted = true;
    })
  }

  updateRole() {
    const role = this.roleForm.value;
    this.roleService.updateRole(this.roleId, role).subscribe(
      response => {
        this.customSnackBarService.successMessage(response.message)
        this.router.navigate(['role']);
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
    return this.roleForm.controls;
  }
}
