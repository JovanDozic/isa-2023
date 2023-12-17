import { Component, OnInit } from '@angular/core';
import { CompanyManagementService } from '../company-management.service';
import { Company } from '../model/company.model';
import { ActivatedRoute } from '@angular/router';
import { Equipment } from '../model/equipment.model';
import { Appointment } from '../model/appointment.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../core/auth/auth.service';
import { User } from '../../../core/auth/model/user.model';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrl: './company.component.css',
})
export class CompanyComponent implements OnInit {
  company!: Company;
  admins: User[] = [];
  companyId!: number;
  shouldEdit: boolean = false;
  equipment: Equipment[] = [];
  appointments: Appointment[] = [];
  selectedItems: Equipment[] = [];
  selectedItem?: Equipment;
  user!: User;

  constructor(private service: CompanyManagementService,
              private route: ActivatedRoute,
              private fb: FormBuilder,
              private authService: AuthService) { }

  ngOnInit(): void {
    this.user = this.authService.user$.getValue();

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
    this.service.getCompanyAdmins(this.companyId, this.user.id).subscribe({
      next: response => {
        this.admins = response;
      }
    })
    this.service.getFreeAppointments(this.companyId).subscribe({
      next: response => {
        this.appointments = response;
      }
    })
  }

  onEditClicked() {
    this.shouldEdit = true;
  }

  setSelectedItem(item: Equipment) {
    this.selectedItems.push(item);
    this.selectedItem = item;
  }
}
