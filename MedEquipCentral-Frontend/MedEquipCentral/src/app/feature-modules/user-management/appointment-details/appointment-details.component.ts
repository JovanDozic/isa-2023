import { Component, OnInit } from '@angular/core';
import { User } from '../../../core/auth/model/user.model';
import { AuthService } from '../../../core/auth/auth.service';
import { UserManagementService } from '../user-management.service';
import { Appointment } from '../../company-management/model/appointment.model';
import { ActivatedRoute } from '@angular/router';
import { Company } from '../../company-management/model/company.model';
import { Equipment } from '../../company-management/model/equipment.model';

@Component({
  selector: 'app-appointment-details',
  standalone: false,
  templateUrl: './appointment-details.component.html',
  styleUrl: './appointment-details.component.css'
})
export class AppointmentDetailsComponent implements OnInit {

  user!: User;
  appointment!: Appointment;
  company!: Company;
  equipment: Equipment[] = []; 

  constructor(private authService: AuthService,
              private userService: UserManagementService,
              private route: ActivatedRoute, ) {

  }

  ngOnInit(): void {

    this.route.params.subscribe(params => {
      let appointmentId = params['id'];
      
      this.userService.getAppointment(appointmentId).subscribe({
        next: response => {
          this.appointment = response;

          this.userService.getUserById(this.appointment.buyerId).subscribe({
            next: response => {
              this.user = response;
            }
          })

          this.userService.getCompany(this.appointment.companyId).subscribe({
            next: response => {
              this.company = response;
            }
          })

          this.appointment.equipmentIds?.forEach(element => {
            this.userService.getEquipment(element).subscribe({
              next: response => {
                this.equipment.push(response);
              }
            });
          });
        }
      })
    })
  }
}
