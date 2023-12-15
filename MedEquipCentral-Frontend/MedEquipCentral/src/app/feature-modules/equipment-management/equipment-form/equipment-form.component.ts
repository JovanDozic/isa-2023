import { Component, Input, OnInit } from '@angular/core';
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
export class EquipmentFormComponent implements OnInit {
  @Input() isEdit: boolean = false;
  @Input() equipment?: Equipment = undefined;
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
      id: [0, Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required],
      typeId: [0, Validators.required],
      companyId: [this.companyId, Validators.required],
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
    if (this.isEdit && this.equipment != undefined) {
      console.log(this.equipment);
      this.equipmentForm.patchValue(this.equipment);
      this.setFormAvailabilty();
    }
  }

  addEquipment() {
    if (this.equipmentForm.valid) {
      const equipment: Equipment = {
        id: this.equipmentForm.value.id,
        name: this.equipmentForm.value.name,
        description: this.equipmentForm.value.description,
        typeId: this.equipmentForm.value.typeId,
        companyId: this.equipmentForm.value.companyId,
        quantity: this.equipmentForm.value.quantity,
      }

      this.equipmentService.addEquipment(equipment).subscribe({
        next: response => {
          console.log(response);
          window.location.reload();
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
        quantity: this.equipmentForm.value.quantity,
      }

      this.equipmentService.updateEquipment(equipment).subscribe({
        next: response => {
          console.log(response);
          window.location.reload();
        }
      })
    }
  }
}
