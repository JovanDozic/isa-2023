import { Component, OnInit } from '@angular/core';
import { User } from '../../../core/auth/model/user.model';
import { AuthService } from '../../../core/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  user!: User;

  constructor(private authService: AuthService, private router: Router) {
  }
  ngOnInit(): void {
    this.user = this.authService.user$.getValue();
  }
}
