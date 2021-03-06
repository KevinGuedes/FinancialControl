import { TypeService } from '../app/services/type.service'
import { CategoryService } from '../app/services/category.service';
import { RoleService } from './services/role.service';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDialogModule } from '@angular/material/dialog';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { FormsModule } from '@angular/forms';
import { MatTooltipModule } from '@angular/material/tooltip';

import { AppComponent } from './app.component';
import { CategoryReadComponent, DialogCategoryDeleteComponent } from './components/category/category-read/category-read.component';
import { CategoryCreateComponent } from './components/category/category-create/category-create.component';
import { CategoryUpdateComponent } from './components/category/category-update/category-update.component';
import { CustomSnackBarComponent } from './components/message/custom-snack-bar/custom-snack-bar.component';
import { RoleReadComponent, DialogRoleDeleteComponent } from './components/role/role-read/role-read.component';
import { RoleCreateComponent } from './components/role/role-create/role-create.component';
import { InvalidFieldsComponent } from './components/templates/invalid-fields/invalid-fields.component';
import { RoleUpdateComponent } from './components/role/role-update/role-update.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoryReadComponent,
    CategoryCreateComponent,
    CategoryUpdateComponent,
    DialogCategoryDeleteComponent,
    CustomSnackBarComponent,
    RoleReadComponent,
    DialogRoleDeleteComponent,
    RoleCreateComponent,
    InvalidFieldsComponent,
    RoleUpdateComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    ReactiveFormsModule,
    FormsModule, //This module prevents 'enter key' to reload page on forms 
    MatDividerModule,
    MatSelectModule,
    MatProgressBarModule,
    MatGridListModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatSnackBarModule,
    MatTooltipModule,
  ],
  providers: [
    TypeService,
    CategoryService,
    RoleService,
    HttpClientModule,
  ],
  entryComponents: [
    DialogCategoryDeleteComponent,
    DialogRoleDeleteComponent,
    CustomSnackBarComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
