import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthModule } from './core/auth/auth.module';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { SharedModule } from './shared/shared.module';
import { LayoutModule } from './feature-modules/layout/layout.module';
import { CompanyManagementModule } from './feature-modules/company-management/company-management.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './core/app-routing/app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent, 
  ],
  imports: [
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserModule,
    AuthModule,
    HttpClientModule,
    RouterModule,
    SharedModule,
    LayoutModule,
    CompanyManagementModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
