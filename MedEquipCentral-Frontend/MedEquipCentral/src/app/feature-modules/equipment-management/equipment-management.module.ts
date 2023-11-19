import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentSearchComponent } from './equipment-search/equipment-search.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    EquipmentSearchComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
  ],
  exports: [
    EquipmentSearchComponent,
  ]
})
export class EquipmentManagementModule { }
