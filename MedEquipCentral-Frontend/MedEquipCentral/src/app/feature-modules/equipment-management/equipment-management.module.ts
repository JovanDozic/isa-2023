import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentSearchComponent } from './equipment-search/equipment-search.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EquipmentFormComponent } from './equipment-form/equipment-form.component';



@NgModule({
  declarations: [
    EquipmentSearchComponent,
    EquipmentFormComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    EquipmentSearchComponent,
    EquipmentFormComponent,
  ]
})
export class EquipmentManagementModule { }
