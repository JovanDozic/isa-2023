import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from '../../app.component';
import { CompanyFormComponent } from './company-form/company-form.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompanyComponent } from './company/company.component';
import { CompaniesComponent } from './companies/companies.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppointmentFormComponent } from './company/appointment-form/appointment-form.component';
import { EquipmentManagementModule } from "../equipment-management/equipment-management.module";



@NgModule({
  declarations: [
    CompanyFormComponent,
    CompanyComponent,
    CompaniesComponent,
    AppointmentFormComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    EquipmentManagementModule,
  ],
  exports:[
    CompanyComponent,
    CompanyFormComponent,
    CompaniesComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class CompanyManagementModule { }
