import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentSearchComponent } from './equipment-search/equipment-search.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    EquipmentSearchComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
  ],
  exports: [
    EquipmentSearchComponent,
  ]
})
export class EquipmentManagementModule { }
