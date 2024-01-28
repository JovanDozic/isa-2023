import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { AuthModule } from '../core/auth/auth.module';
import { FormsModule } from '@angular/forms';
import { LeafletModule } from '@asymmetrik/ngx-leaflet';
import { MapComponent } from './map/map.component';

@NgModule({
  declarations: [
    MapComponent,
  ],
  imports: [
    RouterModule,
    HttpClientModule,
    BrowserModule,
    AuthModule,
    FormsModule,
    //LayoutModule,
    LeafletModule,
  ],
  exports: [
    MapComponent,
  ]
})
export class SharedModule { }
