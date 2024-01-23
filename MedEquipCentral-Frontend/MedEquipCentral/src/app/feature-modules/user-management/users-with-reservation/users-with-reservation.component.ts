import { Component, OnInit } from '@angular/core';
import { User } from '../../../core/auth/model/user.model';
import { UserManagementService } from '../user-management.service';
import { AuthService } from '../../../core/auth/auth.service';

@Component({
  selector: 'app-users-with-reservation',
  templateUrl: './users-with-reservation.component.html',
  styleUrl: './users-with-reservation.component.css'
})
export class UsersWithReservationComponent implements OnInit {
  users: User[] = [];

  constructor(private service: UserManagementService, private authService: AuthService) {
        
  }

  ngOnInit(): void {
    this.service.getAllWithReservation(this.authService.user$.getValue().companyId!).subscribe({
      next: response => {
        this.users = response;
      }
    })
  }
}
