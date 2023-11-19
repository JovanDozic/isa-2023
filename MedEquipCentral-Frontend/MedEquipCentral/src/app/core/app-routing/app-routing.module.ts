import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../../feature-modules/layout/home/home.component';
import { CompanyFormComponent } from '../../feature-modules/company-management/company-form/company-form.component';
import { CompanyComponent } from '../../feature-modules/company-management/company/company.component';
import { EquipmentSearchComponent } from '../../feature-modules/equipment-management/equipment-search/equipment-search.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'company-form', component: CompanyFormComponent },
  { path: 'company/:id', component: CompanyComponent },
  { path: 'equipment/search', component: EquipmentSearchComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
