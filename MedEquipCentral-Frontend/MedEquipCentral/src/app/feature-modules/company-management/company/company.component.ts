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
  companyId!: number;
  shouldEdit: boolean = false;
  
  constructor(private service: CompanyManagementService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.companyId = params['id'];
      this.getCompany();
    })

  }

  getCompany() {
    this.service.getCompany(this.companyId).subscribe({
      next: response => {
        this.company = response;
      }
    })
    this.service.getCompanyAdmins(this.companyId).subscribe({
      next: response => {
        this.admins = response;
      }
    })
  }

  onEditClicked() {
    this.shouldEdit = true;
  }
}
