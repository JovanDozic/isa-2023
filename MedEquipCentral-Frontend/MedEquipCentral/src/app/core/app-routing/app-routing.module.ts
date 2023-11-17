import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../../feature-modules/layout/home/home.component';
import { CompanyFormComponent } from '../../feature-modules/company-management/company-form/company-form.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'company-form', component: CompanyFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
