import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryCreateComponent } from './components/category/category-create/category-create.component';
import { CategoryReadComponent } from './components/category/category-read/category-read.component'
import { CategoryUpdateComponent } from './components/category/category-update/category-update.component';

const routes: Routes = [
  { path: 'category', component: CategoryReadComponent },
  { path: 'category/create', component: CategoryCreateComponent },
  { path: 'category/update/:id', component: CategoryUpdateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
