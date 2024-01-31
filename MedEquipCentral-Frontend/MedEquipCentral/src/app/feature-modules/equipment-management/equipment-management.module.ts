import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentSearchComponent } from './equipment-search/equipment-search.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EquipmentFormComponent } from './equipment-form/equipment-form.component';
import { DeliveryComponent } from './delivery/delivery.component';
import { SharedModule } from '../../shared/shared.module';



@NgModule({
  declarations: [
    EquipmentSearchComponent,
    EquipmentFormComponent,
    DeliveryComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ],
  exports: [
    EquipmentSearchComponent,
    EquipmentFormComponent,
    DeliveryComponent
  ]
})
export class EquipmentManagementModule { }
