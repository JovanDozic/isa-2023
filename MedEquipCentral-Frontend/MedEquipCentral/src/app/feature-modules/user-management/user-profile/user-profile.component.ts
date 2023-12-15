import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { User } from '../model/user.model';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserManagementService } from '../user-management.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent {
  user: User = {
    id: 0,
    name: '',
    surname: '',
    email: '',
    city: '',
    companyInfo: '',
    confirmPassword: '',
    country: '',
    job: '',
    password: '',
    phone: '',
  };
  id: number = 1;

  constructor(private fb: FormBuilder,
              public userService: UserManagementService){}

    ngOnInit(): void {
    this.userService.getUserById(this.id).subscribe({
      next: resposne => {
        console.log(resposne);
        this.user = resposne;
      },
      error: err => {
        console.log(err);
      }
    });
  }

  editInfo(){
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
