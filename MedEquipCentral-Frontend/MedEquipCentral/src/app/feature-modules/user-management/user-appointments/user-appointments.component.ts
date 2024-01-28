import { Component, OnInit } from '@angular/core';
import { Appointment } from '../../company-management/model/appointment.model';
import { UserManagementService } from '../user-management.service';
import { AuthService } from '../../../core/auth/auth.service';
import { User } from '../../../core/auth/model/user.model';
import { Router } from '@angular/router';
import { CompanyManagementService } from '../../company-management/company-management.service';

@Component({
  selector: 'app-user-appointments',
  standalone: false,
  templateUrl: './user-appointments.component.html',
  styleUrl: './user-appointments.component.css'
})
export class UserAppointmentsComponent implements OnInit{

  appointments: Appointment[] = [];
  user!: User
  penalizedUsers: User[] = [];

  constructor(private service: UserManagementService,
              private authService: AuthService,
              private appointmentService: CompanyManagementService,
              private router: Router){

  }
  ngOnInit(): void {
    this.user = this.authService.user$.getValue();
    if (this.user.id == 0) {
      console.log("User not logged in");
      return;
    }
    else if(this.user.userRole?.toString() == 'Company_Admin') this.penalizeUncollectedAppointments();
    else this.getData();
    
  }

  getData() {
    let obj = {
      pageInfo: {
        page: 1,
        size: 10
      },
      userId: this.user.id,
      isAdmin: this.user.userRole?.toString() == 'Company_Admin' ? true : false,
      sortBy: '',
      isAsc: true,
    }
    this.service.getAllUserAppointments(obj).subscribe({
      next: response => {
        this.appointments = response.result;
      }
    })
  }

  viewMore(id: number){
    this.router.navigate(['/appointment-details/'+id]);
  }

  cancel(appointment: Appointment){
    console.log("Usao");
    this.appointmentService.cancelAppointment(appointment);
  }

  penalizeUncollectedAppointments(){
    this.service.penalizeUncollectedAppointments(this.user.id).subscribe({
      next: response =>{
        this.penalizedUsers = response;
        this.getData();
      }
    })
  }

  markAsCollected(appointment: Appointment) {

    this.service.flagAsPickedUp(appointment.id).subscribe({
      next: response => {
        this.getData();
        this.service.reduceQuantityOfCollected(appointment.id).subscribe();
        //this.service.sendCollectionConfirmationEmail(appointment).subscribe();
      }
    })
  }
}
