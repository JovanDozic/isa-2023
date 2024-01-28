import { Component } from '@angular/core';
import { Appointment } from '../../company-management/model/appointment.model';
import { Router } from '@angular/router';
import { UserManagementService } from '../user-management.service';
import { AuthService } from '../../../core/auth/auth.service';
import { User } from '../../../core/auth/model/user.model';

@Component({
  selector: 'app-appointments-history',
  standalone: false,
  templateUrl: './appointments-history.component.html',
  styleUrl: './appointments-history.component.css'
})
export class AppointmentsHistoryComponent {

  appointments: Appointment[] = [];
  user!: User

  constructor(private service: UserManagementService,
              private authService: AuthService,
              private router: Router){

  }
  ngOnInit(): void {
    this.user = this.authService.user$.getValue();
    if (this.user.id == 0) {
      console.log("User not logged in");
      return;
    }
    else this.getData();    
  }

  getData() {
    let obj = {
      pageInfo: {
        page: 1,
        size: 1000
      },
      userId: this.user.id,
      sortBy: '',
      isAsc: true,
    }
    this.service.getHistory(obj).subscribe({
      next: response => {
        this.appointments = response.result;
      }
    })
  }

  viewMore(id: number){
    this.router.navigate(['/appointment-details/'+id]);
  }

}
