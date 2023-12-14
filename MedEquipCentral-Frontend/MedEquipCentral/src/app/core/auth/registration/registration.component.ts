import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Registration } from '../model/registration.model';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  registrationForm = new FormGroup({
    email: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    confirmedPassword: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required]),
    surname: new FormControl('', [Validators.required]),
    city: new FormControl('', [Validators.required]),
    country: new FormControl('', [Validators.required]),
    phone: new FormControl('', [Validators.required]),
    job: new FormControl('', [Validators.required]),
    companyInfo: new FormControl(''),
  });

  register(): void {
    const registration: Registration = {
      email: this.registrationForm.value.email || "",
      password: this.registrationForm.value.password || "",
      confirmedPassword: this.registrationForm.value.confirmedPassword || "",
      name: this.registrationForm.value.name || "",
      surname: this.registrationForm.value.surname || "",
      city: this.registrationForm.value.city || "",
      country: this.registrationForm.value.country || "",
      phone: this.registrationForm.value.phone || "",
      job: this.registrationForm.value.job || "",
      companyInfo: this.registrationForm.value.companyInfo || "",
    };
    if (this.registrationForm.valid) {
      this.authService.register(registration).subscribe({
        next: () => {
          this.router.navigate(['home']);
        },
      });
    }
  }
}
