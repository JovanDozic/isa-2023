import { Component, OnInit } from '@angular/core';
import { CompanyManagementService } from '../company-management.service';
import { Company } from '../model/company.model';
import { ActivatedRoute } from '@angular/router';
import { User } from '../model/user.model';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrl: './company.component.css',
})
export class CompanyComponent implements OnInit {
  company?: Company;
  admins: User[] = [];
  constructor(private service: CompanyManagementService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const tourId = params['id'];

      this.service.getCompany(tourId).subscribe({
        next: response => {
          this.company = response;
        }
      })
      this.service.getCompanyAdmins(tourId).subscribe({
        next: response => {
          this.admins = response;
        }
      })
    })

  }
}
