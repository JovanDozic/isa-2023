import { Component, OnInit } from '@angular/core';
import { Appointment } from '../../company-management/model/appointment.model';
import { UserManagementService } from '../user-management.service';
import { AuthService } from '../../../core/auth/auth.service';
import { User } from '../../../core/auth/model/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-appointments',
  standalone: false,
  templateUrl: './user-appointments.component.html',
  styleUrl: './user-appointments.component.css'
})
export class UserAppointmentsComponent implements OnInit{

  appointments: Appointment[] = [];
  user!: User

  constructor(private service: UserManagementService,
              private authService: AuthService,
              private router: Router){

  }
  ngOnInit(): void {
    this.authService.user$.subscribe(user => {
      if (user.id == 0) {
        console.log("User not logged in");
        return;
      }
      this.service.getUserById(user.id).subscribe({
        next: resposne => {
          this.user = resposne;

          this.getData();
        },
        error: err => {
          this.user.id = 0;
          console.log(err);
        }
      })
    });
  }

  getData() {
    let obj = {
      pageInfo: {
        page: 1,
        size: 10
      },
      userId: this.user.id
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
}
