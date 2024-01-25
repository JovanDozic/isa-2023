import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentSearchComponent } from './equipment-search/equipment-search.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EquipmentFormComponent } from './equipment-form/equipment-form.component';
import { PickupUsingQrComponent } from './pickup-using-qr/pickup-using-qr.component';
import { ZXingScannerModule } from '@zxing/ngx-scanner';



@NgModule({
  declarations: [
    EquipmentSearchComponent,
    EquipmentFormComponent,
    PickupUsingQrComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    ZXingScannerModule,
  ],
  exports: [
    EquipmentSearchComponent,
    EquipmentFormComponent,
    PickupUsingQrComponent,
  ]
})
export class EquipmentManagementModule { }
