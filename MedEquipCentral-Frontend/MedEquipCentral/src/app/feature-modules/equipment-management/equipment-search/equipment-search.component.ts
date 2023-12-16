import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { EquipmentService } from '../equipment.service';
import { Equipment } from '../../company-management/model/equipment.model';
import { EquipmentType } from '../../company-management/model/equipment-type.model';
import { AuthService } from '../../../core/auth/auth.service';
import { User } from '../../../core/auth/model/user.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-equipment-search',
  templateUrl: './equipment-search.component.html',
  styleUrl: './equipment-search.component.css'
})
export class EquipmentSearchComponent implements OnInit, OnChanges {
  @Input() showForCompany: boolean = false;
  equipment: Equipment[] = [];
  equipmentOriginal: Equipment[] = [];
  equipmentTypes: EquipmentType[] = [];
  searchTerm: string = '';
  selectedType?: EquipmentType = undefined;
  sortDirection?: boolean = undefined;
  user!: User;
  isEdit: boolean = false;
  selectedEquipment?: Equipment = undefined;

  reservedEquipmentId: number[] = [];

  constructor(private equipmentService: EquipmentService, private authService: AuthService, private route: ActivatedRoute) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.getEquipment();
    this.getEquipmentTypes();
  }

  ngOnInit(): void {
    this.authService.user$.subscribe(user => {
      this.user = user;
    });

    this.getEquipment();
    this.getEquipmentTypes();
  }

  getEquipment() {
    if (!this.showForCompany) {
      this.equipmentService.getEquipment().subscribe(
        (response: any) => {
          this.equipment = response;
          this.equipmentOriginal = response;
          console.log(this.equipment);
        },
        (error) => console.log(error)
      );
    }
    else {
      this.route.params.subscribe(params => {
        const companyId = params['id'];
        this.equipmentService.getEquipmentForCompany(companyId).subscribe(
          (response: any) => {
            this.equipment = response;
            this.equipmentOriginal = response;
            console.log(this.equipment);
          },
          (error) => console.log(error)
        );
      })
    }
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
        equipmentItem.type?.id === this.selectedType?.id
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

  setIsEditFalse() {
    this.isEdit = false;
    this.selectedEquipment = undefined;
  }

  setIsEditTrue(equipment: Equipment) {
    this.isEdit = true;
    this.selectedEquipment = equipment;
  }

  deleteEquipment(equipment: Equipment) {
    if (confirm('Are you sure you wish to delete ' + equipment.name)) {
      this.equipmentService.delete(equipment.id!).subscribe({
        next: response => {
          if (response == true)
            this.getEquipment();
          else
            alert('Cannot delete because there is an active appointment!');
        }
      })
    }
  }

  addToCart(equipmentId: number){
    this.reservedEquipmentId.push(equipmentId)

    this.equipment.forEach(element => {
      if(element.id == equipmentId){
        element.quantity -= 1;
      }
    });
  }

}
