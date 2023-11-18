import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from '../../app.component';
import { CompanyFormComponent } from './company-form/company-form.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompanyComponent } from './company/company.component';
import { CompaniesComponent } from './companies/companies.component';


@NgModule({
  declarations: [
    CompanyFormComponent,
    CompanyComponent,
    CompaniesComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  exports:[
    CompanyComponent,
    CompanyFormComponent,
    CompaniesComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class CompanyManagementModule { }
