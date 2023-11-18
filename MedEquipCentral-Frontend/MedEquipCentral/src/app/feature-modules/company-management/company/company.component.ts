import { Component, OnInit } from '@angular/core';
import { CompanyManagementService } from '../company-management.service';
import { Company } from '../model/company.model';
import { ActivatedRoute } from '@angular/router';
import { User } from '../../user-management/model/user.model';
import { Equipment } from '../model/equipment.model';
import { Appointment } from '../model/appointment.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrl: './company.component.css',
})
export class CompanyComponent implements OnInit {
  company?: Company;
  admins: User[] = [];
  companyId!: number;
  shouldEdit: boolean = false;
  equipment: Equipment[] = [];
  selectedItem?: Equipment;
  appointmentForm!: FormGroup;


  constructor(private service: CompanyManagementService, private route: ActivatedRoute, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.companyId = params['id'];
      this.getCompany();
    })

    this.appointmentForm = this.fb.group({
      appointmentDate: ['', Validators.required]
    })

  }

  getCompany() {
    this.service.getCompany(this.companyId).subscribe({
      next: response => {
        this.company = response;
      }
    })
    this.service.getCompanyAdmins(this.companyId).subscribe({
      next: response => {
        this.admins = response;
      }
    })
    this.service.getEquipment(this.companyId).subscribe({
      next: response => {
        this.equipment = response;
      }
    })
  }

  onEditClicked() {
    this.shouldEdit = true;
  }

  setSelectedItem(item: Equipment) {
    this.selectedItem = item;
  }

  makeAppointment() {
    if (this.appointmentForm.valid && this.selectedItem != undefined && this.selectedItem.id != undefined) {
      const appointment: Appointment = {
        userId: 1,
        equipmentId: this.selectedItem.id,
        companyId: this.companyId,
        date: this.appointmentForm.value.appointmentDate,
      }
      console.log(appointment.date);

      this.service.makeAppointment(appointment).subscribe({
        next: response => {
          console.log(response);
        },
        error: err => {
          console.log(err);
        }
      })
    }
  }
}
