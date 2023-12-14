import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../../../core/auth/model/user.model';

@Component({
  selector: 'app-system-admins-management',
  templateUrl: './system-admins-management.component.html',
  styleUrl: './system-admins-management.component.css'
})
export class SystemAdminsManagementComponent implements OnInit {


  regUsers: User[] = [];
  sysAdmins: User[] = [];

  constructor(private userService: UserService) { }


  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.userService.getAllRegistered().subscribe(
      (response: any) => {
        this.regUsers = response;
        console.log(this.regUsers);
      },
      (error) => console.log(error)
    );
    this.userService.getAllSystemAdmins().subscribe(
      (response: any) => {
        this.sysAdmins = response;
        console.log(this.sysAdmins);
      },
      (error) => console.log(error)
    );
  }

  removeSystemAdmin() {
    throw new Error('Method not implemented.');
  }


  
  addSystemAdmin() {
    throw new Error('Method not implemented.');
  }

}
