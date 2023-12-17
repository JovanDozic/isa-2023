import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserManagementService } from '../user-management.service';
import { User } from '../../../core/auth/model/user.model';
import { AuthService } from '../../../core/auth/auth.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent {
  user!: User;

  constructor(private fb: FormBuilder, public authService: AuthService, public userService: UserManagementService) { }

  ngOnInit(): void {
    this.authService.user$.subscribe(user => {
      if (user.id == 0) {
        console.log("User not logged in");
        return;
      }
      this.userService.getUserById(user.id).subscribe({
        next: resposne => {
          console.log(resposne);
          this.user = resposne;
        },
        error: err => {
          this.user.id = 0;
          console.log(err);
        }
      })
    });
  }

  editInfo() {
    this.userService.update(this.user).subscribe({
      next: resposne => {
        console.log(resposne);
        this.user = resposne;
      },
      error: err => {
        console.log(err);
      }
    })
  }
}
