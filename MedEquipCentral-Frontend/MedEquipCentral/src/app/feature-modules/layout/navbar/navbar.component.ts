import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  constructor(private router: Router) { }

  public ViewCompanyById() {
    const companyId = prompt("Enter company ID:");
    if (companyId) {
      this.router.navigate([`/company/${companyId}`]);
    }
  }

}
