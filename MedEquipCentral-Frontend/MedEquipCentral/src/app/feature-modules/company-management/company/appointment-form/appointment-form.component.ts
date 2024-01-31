import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CompanyManagementService } from '../../company-management.service';
import { Appointment, AppointmentStatus } from '../../model/appointment.model';
import { Company } from '../../model/company.model';
import { User } from '../../../../core/auth/model/user.model';
import { UserManagementService } from '../../../user-management/user-management.service';

@Component({
  selector: 'app-appointment-form',
  standalone: false,
  templateUrl: './appointment-form.component.html',
  styleUrl: './appointment-form.component.css',
})
export class AppointmentFormComponent implements OnInit {
  appointmentForm!: FormGroup;
  company!: Company;
  createYourOwn: boolean = false;
  appointmentId: number = 0;
  penalPoints?: number;

  @Input() companyId: number = 0;
  @Input() user!: User;
  @Input() appointments: Appointment[] = [];
  @Input() reservedEquipmentId: number[] = [];
  @Output() appointmentAdded = new EventEmitter<null>();

  constructor(
    private service: CompanyManagementService,
    private userService: UserManagementService,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.userService.getUserById(this.user.id).subscribe({
      next: response => {
        console.log(response);
        this.user = response;
      },
      error: err => {
        this.user.id = 0;
        console.log(err);
      }
    })
    this.appointmentForm = this.fb.group({
      appointmentDate: ['', Validators.required],
      duration: ['', Validators.required],
    });

    this.penalPoints =  this.user.penalPoints
  }

  createAppointment() {
    if(this.user.penalPoints){
      if(this.user.penalPoints >= 3) {
        alert("You have 3 or more penal point so you can not make appointment")
        return;
      }
    }
    if (this.reservedEquipmentId.length === 0) {
      const appointment: Appointment = {
        id: 0,
        startTime: this.appointmentForm.value.appointmentDate,
        duration: this.appointmentForm.value.duration,
        companyId: this.companyId,
        adminId: this.user.id,
        equipment: [],
        company: this.company,
      };
      console.log(this.reservedEquipmentId);
      console.log(appointment.equipmentIds);

      this.service.createAppointment(appointment).subscribe({
        next: (response) => {
          console.log(response);
          this.appointmentAdded.emit();
        },
        error: (err) => {
          console.log(err);
          this.appointmentAdded.emit();
        },
      });
    } else if (!this.createYourOwn) {
      const appointment: Appointment = {
        id: this.appointmentId,
        startTime: this.appointmentForm.value.appointmentDate,
        duration: this.appointmentForm.value.duration,
        companyId: this.companyId,
        adminId: 0,
        buyerId: this.user.id,
        equipmentIds: this.reservedEquipmentId,
        equipment: [],
        company: this.company,
        status: 0,
      };
      this.service.updateAppointment(appointment).subscribe({
        next: (response) => {
          console.log(response);
          this.appointmentAdded.emit();
        },
        error: (err) => {
          console.log(err);
        },
      });
    } else {
      const appointment: Appointment = {
        id: 0,
        startTime: this.appointmentForm.value.appointmentDate,
        duration: this.appointmentForm.value.duration,
        companyId: this.companyId,
        adminId: 0,
        buyerId: this.user.id,
        equipmentIds: this.reservedEquipmentId,
        equipment: [],
        company: this.company,
        status: 0,
      };
      console.log(this.reservedEquipmentId);
      console.log(appointment.equipmentIds);

      this.service.createAppointment(appointment).subscribe({
        next: (response) => {
          console.log(response);
          this.appointmentAdded.emit();
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }

  createAppointmentBuyer() {
    //if (this.appointmentForm.valid) {
    const appointment: Appointment = {
      id: 0,
      startTime: this.appointmentForm.value.appointmentDate,
      duration: this.appointmentForm.value.duration,
      companyId: this.companyId,
      adminId: 0,
      buyerId: this.user.id,
      equipmentIds: this.reservedEquipmentId,
      equipment: [],
      company: this.company,
      status: AppointmentStatus.NEW,
      // adminName: '',
      // adminSurname: '',
    };
    console.log(this.reservedEquipmentId);
    console.log(appointment.equipmentIds);

    this.service.createAppointment(appointment).subscribe({
      next: (response) => {
        console.log(response);
        this.appointmentAdded.emit();
      },
      error: (err) => {
        console.log(err);
      },
    });
    //}
  }

  getCompany() {
    this.service.getCompany(this.companyId).subscribe({
      next: (response) => {
        this.company = response;
      },
    });
  }

  createYourOwnFunction() {
    this.createYourOwn = true;
  }

  getReservedEquipment(reservedEquipmentIds: any) {
    this.reservedEquipmentId = reservedEquipmentIds;
  }

  selectAppointment(appointment: any) {
    this.appointmentId = appointment.id;
    this.appointmentForm.value.appointmentDate = appointment.startTime;
    this.appointmentForm.value.duration = appointment.duration;
  }
}
