import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { User } from '../../../core/auth/model/user.model';
import { UserManagementService } from '../user-management.service';

@Component({
  selector: 'app-system-admins-management',
  templateUrl: './system-admins-management.component.html',
  styleUrl: './system-admins-management.component.css'
})
export class SystemAdminsManagementComponent implements OnInit, OnChanges {


  regUsers: User[] = [];
  sysAdmins: User[] = [];

  constructor(private userService: UserManagementService) { }

  ngOnChanges(changes: SimpleChanges): void {
    throw new Error('Method not implemented.');
  }

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

  removeSystemAdmin(user: User) {
    this.userService.removeSystemAdmin(user.id).subscribe(
      (response: any) => {
        this.sysAdmins = this.sysAdmins.filter((u) => u.id !== user.id);
        this.regUsers.push(user);
      },
      (error) => console.log(error)
    );
  }



  addSystemAdmin(user: User) {
    this.userService.addSystemAdmin(user.id).subscribe(
      (response: any) => {
        this.regUsers = this.regUsers.filter((u) => u.id !== user.id);
        this.sysAdmins.push(user);
        console.log(this.sysAdmins);
        console.log(this.regUsers);
      },
      (error) => console.log(error)
    );
  }

}
