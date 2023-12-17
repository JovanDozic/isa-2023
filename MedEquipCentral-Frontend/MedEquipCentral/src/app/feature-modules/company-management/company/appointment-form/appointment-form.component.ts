import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { CompanyManagementService } from '../../company-management.service';
import { Appointment } from '../../model/appointment.model';
import { Company } from '../../model/company.model';
import { User } from '../../../../core/auth/model/user.model';

@Component({
  selector: 'app-appointment-form',
  standalone: false,
  templateUrl: './appointment-form.component.html',
  styleUrl: './appointment-form.component.css'
})
export class AppointmentFormComponent implements OnInit {
  appointmentForm!: FormGroup;
  company!: Company

  @Input() companyId: number = 0;
  @Input() user!: User
  @Output() appointmentAdded = new EventEmitter<null>();

  constructor(private service: CompanyManagementService, 
              private route: ActivatedRoute, 
              private fb: FormBuilder) {}

  ngOnInit(): void {
    this.appointmentForm = this.fb.group({
      appointmentDate: ['', Validators.required],
      duration: ['', Validators.required],
    })
  }
              
  createAppointment() {
    if (this.appointmentForm.valid) {
      const appointment: Appointment = {
        id: 0,
        startTime: this.appointmentForm.value.appointmentDate,
        duration: this.appointmentForm.value.duration,
        companyId: this.companyId,
        adminName: this.user.name,
        adminSurname: this.user.surname,
        adminId: this.user.id,
        buyerId: 1,
        equipmentIds: []
      }
      console.log(appointment.startTime);

      this.service.createAppointment(appointment).subscribe({
        next: response => {
          console.log(response);
          this.appointmentAdded.emit();
        },
        error: err => {
          console.log(err);
        }
      })
    }
  }

  getCompany() {
    this.service.getCompany(this.companyId).subscribe({
      next: response => {
        this.company = response;
      }
    })
  }
}
