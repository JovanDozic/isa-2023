import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { EquipmentService } from '../equipment.service';
import { Equipment } from '../../company-management/model/equipment.model';
import { EquipmentType } from '../../company-management/model/equipment-type.model';

@Component({
  selector: 'app-equipment-search',
  templateUrl: './equipment-search.component.html',
  styleUrl: './equipment-search.component.css'
})
export class EquipmentSearchComponent implements OnInit, OnChanges {

  equipment: Equipment[] = [];
  equipmentOriginal: Equipment[] = [];
  equipmentTypes: EquipmentType[] = [];
  searchTerm: string = '';
  selectedType?: EquipmentType = undefined;
  sortDirection?: boolean = undefined;

  constructor(private equipmentService: EquipmentService) { }

  ngOnChanges(changes: SimpleChanges): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit(): void {
    this.getEquipment();
    this.getEquipmentTypes();
  }

  getEquipment() {
    this.equipmentService.getEquipment().subscribe(
      (response: any) => {
        this.equipment = response;
        this.equipmentOriginal = response;
        console.log(this.equipment);
      },
      (error) => console.log(error)
    );
  }

  getEquipmentTypes() {
    this.equipmentService.getEquipmentTypes().subscribe(
      (response: any) => {
        this.equipmentTypes = response;
        console.log(this.equipmentTypes);
      },
      (error) => console.log(error)
    );
  }

  setTypeFilter(type: EquipmentType) {
    this.selectedType = type;
  }

  searchEquipment() {
    // ovde treba odmah i filter da se primeni
    if (!this.searchTerm) {
      this.getEquipment();
    }
    else {
      this.equipment = this.equipment.filter(equipmentItem =>
        equipmentItem.name.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
      console.log(this.equipment);
    }
    this.searchFilter();
  }

  removeSearch() {
    this.searchTerm = '';
    this.searchEquipment();
  }

  searchFilter() {
    if (this.selectedType) {
      this.equipment = this.equipment.filter(equipmentItem =>
        equipmentItem.type.id === this.selectedType?.id
      );
    }
    if (this.sortDirection !== undefined) {
      this.equipment.sort((a, b) => {
        if (this.sortDirection) {
          return a.name.localeCompare(b.name);
        }
        else {
          return b.name.localeCompare(a.name);
        }
      });
    }
  }

  toggleSortDirection() {
    if (this.sortDirection === undefined) {
      this.sortDirection = true;
    }
    else {
      this.sortDirection = !this.sortDirection;
    }
  }

  removeFilters() {
    this.selectedType = undefined;
    this.sortDirection = undefined;
    this.equipment = this.equipmentOriginal;
    this.searchEquipment();
  }

}
