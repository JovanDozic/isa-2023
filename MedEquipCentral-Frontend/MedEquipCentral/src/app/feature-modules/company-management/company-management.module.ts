import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from '../../app.component';
import { CompanyFormComponent } from './company-form/company-form.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { CompanyComponent } from './company/company.component';


@NgModule({
  declarations: [
    CompanyFormComponent,
    CompanyComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  exports:[
    CompanyComponent,
    CompanyFormComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class CompanyManagementModule { }
