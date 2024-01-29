import { Component } from '@angular/core';
import { User } from '../../../core/auth/model/user.model';
import { UserManagementService } from '../user-management.service';
import { AuthService } from '../../../core/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-qrcodes',
  standalone: false,
  templateUrl: './user-qrcodes.component.html',
  styleUrl: './user-qrcodes.component.css'
})
export class UserQrcodesComponent {

  qrCodes: any[] = [];
  user!: User;

  public filterBys: string[] = ['Collected', 'Cancelled', 'Duration'];
  public filterBy: string = '';

  constructor(private service: UserManagementService,
              private authService: AuthService,
              private router: Router){

  }
  ngOnInit(): void {
    this.user = this.authService.user$.getValue();
    if (this.user.id == 0) {
      console.log("User not logged in");
      return;
    }
    else this.getData();    
  }

  getData() {

    let obj = {
      pageInfo: {
        page: 1,
        size: 1000
      },
      userId: this.user.id,
      filterBy: this.filterBy,
    }
    this.service.getQrCodes(obj).subscribe({
      next: response => {
        this.qrCodes = response;
      }
    })
  }

  viewMore(id: number){
    this.router.navigate(['/appointment-details/'+id]);
  }
}
