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
  company!: Company;
  admins: User[] = [];
  companyId!: number;
  shouldEdit: boolean = false;
  equipment: Equipment[] = [];
  appointments: Appointment[] = [];
  selectedItem?: Equipment;
  appointmentForm!: FormGroup;


  constructor(private service: CompanyManagementService, private route: ActivatedRoute, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.companyId = params['id'];
      this.getCompany();
    })

    this.appointmentForm = this.fb.group({
      appointmentDate: ['', Validators.required],
      duration: ['', Validators.required],
    })

  }

  getCompany() {
    this.service.getCompany(this.companyId).subscribe({
      next: response => {
        this.company = response;
      }
    })
    this.service.getCompanyAdmins(this.companyId, 1).subscribe({
      next: response => {
        this.admins = response;
      }
    })
    this.service.getEquipment(this.companyId).subscribe({
      next: response => {
        this.equipment = response;
      }
    })
    this.service.getFreeAppointments(this.companyId).subscribe({
      next: response => {
        this.appointments = response;
      }
    })
  }

  onEditClicked() {
    this.shouldEdit = true;
  }

  setSelectedItem(item: Equipment) {
    this.selectedItem = item;
  }

  createAppointment() {
    if (this.appointmentForm.valid) {
      const appointment: Appointment = {
        id: 0,
        startTime: this.appointmentForm.value.appointmentDate,
        duration: this.appointmentForm.value.duration,
        companyId: this.companyId,
        adminName: 'admin',
        adminSurname: 'adminic',
        adminId: 1,
      }
      console.log(appointment.startTime);

      this.service.createAppointment(appointment).subscribe({
        next: response => {
          console.log(response);
          this.getCompany();
        },
        error: err => {
          console.log(err);
        }
      })
    }
  }
}
