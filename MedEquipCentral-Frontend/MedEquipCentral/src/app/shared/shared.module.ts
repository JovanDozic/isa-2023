import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from '../core/routing/app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { AuthModule } from '../core/auth/auth.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [],
  imports: [
    AppRoutingModule,
    RouterModule,
    HttpClientModule,
    BrowserModule,
    AuthModule,
    FormsModule,
    //LayoutModule
  ]
})
export class SharedModule { }
