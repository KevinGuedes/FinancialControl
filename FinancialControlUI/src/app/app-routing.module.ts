import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryReadComponent } from './components/category/category-read/category-read.component'

const routes: Routes = [
  {
    path: 'category', component: CategoryReadComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
