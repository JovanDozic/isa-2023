import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../core/auth/auth.service';
import { User } from '../../../core/auth/model/user.model';
import { Equipment } from '../../company-management/model/equipment.model';
import { EquipmentService } from '../equipment.service';
import { EquipmentType } from '../../company-management/model/equipment-type.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-equipment-form',
  templateUrl: './equipment-form.component.html',
  styleUrl: './equipment-form.component.css'
})
export class EquipmentFormComponent implements OnInit, OnChanges {
  @Input() isEdit: boolean = false;
  @Input() equipment?: Equipment = undefined;
  @Output() refreshEquipment = new EventEmitter<null>();
  equipmentTypes!: EquipmentType[];
  equipmentForm!: FormGroup;
  user!: User;
  companyId!: number;

  constructor(private fb: FormBuilder, private authService: AuthService, private equipmentService: EquipmentService,
    private route: ActivatedRoute) { }
  ngOnInit(): void {
    this.authService.user$.subscribe(user => {
      this.user = user;
    });
    this.route.params.subscribe(params => {
      this.companyId = params['id'];
    })

    this.equipmentService.getEquipmentTypes().subscribe({
      next: response => {
        this.equipmentTypes = response;
      }
    })

    this.equipmentForm = this.fb.group({
      name: [undefined, Validators.required],
      description: [undefined, Validators.required],
      typeId: [undefined, Validators.required],
      price: [undefined, Validators.required],
      quantity: [undefined, Validators.required],
    });

    this.setFormAvailabilty();

  }

  setFormAvailabilty(){
    if(this.isEdit){
      this.equipmentForm.controls['name'].disable();
      this.equipmentForm.controls['description'].disable();
      this.equipmentForm.controls['typeId'].disable();
    }
    else{
      this.equipmentForm.controls['name'].enable();
      this.equipmentForm.controls['description'].enable();
      this.equipmentForm.controls['typeId'].enable();
    }
  }

  ngOnChanges() {
    this.equipmentForm.reset();
    this.setFormAvailabilty();
    if (this.isEdit) {
      this.equipmentForm.patchValue(this.equipment!);
    }
  }

  addEquipment() {
    if (this.equipmentForm.valid) {
      const equipment: Equipment = {
        id: 0,
        name: this.equipmentForm.value.name,
        description: this.equipmentForm.value.description,
        typeId: this.equipmentForm.value.typeId,
        companyId: this.companyId,
        quantity: this.equipmentForm.value.quantity,
        price: this.equipmentForm.value.price,
        type: {
          type: ''
        }
      }
      console.log(equipment);

      this.equipmentService.addEquipment(equipment).subscribe({
        next: response => {
          console.log(response);
          this.refreshEquipment.emit();
          this.equipmentForm.reset();
        }
      })
    }
  }

  updateEquipment() {
    if (this.equipmentForm.valid && this.equipment != undefined) {
      const equipment: Equipment = {
        id: this.equipment.id,
        name: this.equipment.name,
        description: this.equipment.description,
        typeId: this.equipment.typeId,
        companyId: this.equipment.companyId,
        price: this.equipmentForm.value.price,
        quantity: this.equipmentForm.value.quantity,
        type: {
          type: ''
        }
      }

      this.equipmentService.updateEquipment(equipment).subscribe({
        next: response => {
          console.log(response);
          this.refreshEquipment.emit();
        }
      })
    }
  }
}
