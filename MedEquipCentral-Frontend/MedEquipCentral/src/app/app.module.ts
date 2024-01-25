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
import { UserManagementModule } from './feature-modules/user-management/user-management.module';
import { UserModule } from './feature-modules/user-management/user.module';
import { EquipmentManagementModule } from './feature-modules/equipment-management/equipment-management.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { ZXingScannerModule } from '@zxing/ngx-scanner';

@NgModule({
  declarations: [
    AppComponent
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
    CompanyManagementModule,
    UserManagementModule,
    UserModule,
    EquipmentManagementModule,
    NgbModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
    ZXingScannerModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
