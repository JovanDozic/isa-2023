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
  user!: User;

  public sortTypes: string[] = ['ASC', 'DESC'];
  public sortType: string = 'ASC';
  public sortBys: string[] = ['Date', 'Price', 'Duration'];
  public sortBy: string = '';

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
    let isAsc = true;
    if(this.sortType === 'DESC')
      isAsc= false;

    let obj = {
      pageInfo: {
        page: 1,
        size: 1000
      },
      userId: this.user.id,
      sortBy: this.sortBy,
      isAsc: isAsc,
    }
    this.service.getHistory(obj).subscribe({
      next: response => {
        this.appointments = response;
      }
    })
  }

  viewMore(id: number){
    this.router.navigate(['/appointment-details/'+id]);
  }

}
