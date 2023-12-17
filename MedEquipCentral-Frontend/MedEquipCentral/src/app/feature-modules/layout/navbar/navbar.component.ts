import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/auth/auth.service';
import { User } from '../../../core/auth/model/user.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit {

  user!: User;

  constructor(private router: Router, private authService: AuthService) { }
  ngOnInit(): void {
    this.user = this.authService.user$.getValue();
    console.log("Navbar loaded this user: ");
    console.log(this.user);
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/home']);
    location.reload();
  }

}
