import { Component, OnInit } from '@angular/core';
import { CompanyManagementService } from '../company-management.service';
import { Company } from '../model/company.model';
import { ActivatedRoute } from '@angular/router';
import { User } from '../../user-management/model/user.model';
import { Equipment } from '../model/equipment.model';
import { Appointment } from '../model/appointment.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../core/auth/auth.service';

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
  selectedItem: Equipment[] = [];
  currentUser!: User

  constructor(private service: CompanyManagementService, 
              private route: ActivatedRoute, 
              private fb: FormBuilder,
              private authService: AuthService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.companyId = params['id'];
      this.getCompany();
    })



    this.currentUser = this.authService.user$.getValue();
  }

  getCompany() {
    this.service.getCompany(this.companyId).subscribe({
      next: response => {
        this.company = response;
      }
    })
    this.service.getCompanyAdmins(this.companyId, 1).subscribe({
      next: response => {
        this.admins = response;
      }
    })
    this.service.getEquipment(this.companyId).subscribe({
      next: response => {
        this.equipment = response;
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
    this.selectedItem.push(item);
  }
}
