import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserManagementService } from '../user-management.service';
import { User } from '../../../core/auth/model/user.model';
import { AuthService } from '../../../core/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-password-form',
  templateUrl: './change-password-form.component.html',
  styleUrl: './change-password-form.component.css'
})
export class ChangePasswordFormComponent implements OnInit {

  user!: User;
  passwordForm!: FormGroup;

  constructor(private fb: FormBuilder,
              private userService: UserManagementService,
              private authService: AuthService,
              private router: Router) {

  }
  ngOnInit(): void {
    this.user = this.authService.user$.getValue();
    this.passwordForm = this.fb.group({
      newPassword: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });
  }

  changePassword() {
    const newPassword = this.passwordForm.value.newPassword;
    const confirmPassword = this.passwordForm.value.confirmPassword;
    if (this.passwordForm.valid && newPassword == confirmPassword) {
      this.userService.changePassword(this.user.id, newPassword).subscribe({
        next: response => {
          this.router.navigate(['/home']);
        }
      })
    }
  }

}
