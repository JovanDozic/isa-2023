import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyManagementService } from '../company-management.service';
import { Company } from '../model/company.model';
import { Observable } from 'rxjs';
import { Location } from '@angular/common';
import { User } from '../../user-management/model/user.model';
import { UserManagementService } from '../../user-management/user-management.service';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrl: './company-form.component.css'
})
export class CompanyFormComponent implements OnInit, OnChanges {

  @Input() company?: Company;
  @Input() admins?: User[];
  @Input() shouldEdit: boolean = false;
  @Output() companyUpdated = new EventEmitter<null>();
  users: User[] = [];
  companyForm!: FormGroup;

  constructor(private fb: FormBuilder, private companyService: CompanyManagementService, private userService: UserManagementService, private location: Location) { }

  ngOnInit(): void {
    this.companyForm = this.fb.group({
      id: [0, Validators.required],
      name: ['', Validators.required],
      locationId: [0, Validators.required],
      location: this.fb.group({
        // latitude: ['', Validators.required],
        // longitude: ['', Validators.required],
        street: ['', Validators.required],
        streetNumber: ['', Validators.required],
        city: ['', Validators.required],
        zip: ['', Validators.required],
        country: ['', Validators.required],
      }),
      description: [''],
      rating: [0, Validators.required],
      selectedAdmin: [null],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
    });

    this.getUsers();
    if (!this.shouldEdit) {
      this.admins = [];
    }
  }

  getUsers() {
    this.userService.getAllRegistered().subscribe(
      (response: User[]) => {
        this.users = response;
      },
      (error) => console.log(error)
    );
  }


  ngOnChanges() {
    this.companyForm.reset();
    if (this.shouldEdit && this.company != undefined) {
      console.log(this.company);
      this.companyForm.patchValue(this.company);
    }
  }

  addCompany() {
    console.log(this.companyForm.value);
    if (this.companyForm.valid) {
      this.companyService.addCompany(this.companyForm.value).subscribe(
        (response) => {
          console.log(response);
          this.companyUpdated.emit();
          this.location.back();
        },
        (error) => console.log(error)
      );
    }
  }

  editCompany() {
    if (this.companyForm.valid && this.company != undefined) {
      const editedCompany: Company = {
        id: this.companyForm.value.id,
        name: this.companyForm.value.name,
        description: this.companyForm.value.description,
        locationId: this.companyForm.value.locationId,
        location: {
          id: this.companyForm.value.locationId,
          latitude: this.company.location.latitude,
          longitude: this.company.location.longitude,
          street: this.companyForm.value.location.street,
          streetNumber: this.companyForm.value.location.streetNumber,
          city: this.companyForm.value.location.city,
          zip: this.companyForm.value.location.zip,
          country: this.companyForm.value.location.country,
        },
        rating: this.company.rating,
        startTime: this.companyForm.value.startTime,
        endTime: this.companyForm.value.endTime,
      }

      console.log(editedCompany);

      this.companyService.updateCompany(editedCompany).subscribe({
        next: resposne => {
          window.location.reload();
        },
        error: err => {
          console.log(err);
        }
      });
    }
  }

  removeUserFromCompany(user: User) {
    this.userService.removeFromCompany(user.id).subscribe(
      (response) => {
        this.admins = this.admins?.filter(u => u.id != user.id);
        this.users.push(user);
        console.log(response);
        this.companyUpdated.emit();
      },
      (error) => console.log(error)
    );
  }

  addUserToCompany() {
    const userId = this.companyForm.value.selectedAdmin;
    let user = this.users.find(u => u.id == userId);
    this.userService.addToCompany(userId, this.companyForm.value.id).subscribe(
      (response) => {
        if (user != undefined)
          this.admins?.push(user);
        this.users = this.users.filter(u => u.id != userId);
        console.log(response);
        this.companyUpdated.emit();
      },
      (error) => console.log(error)
    );
  }

}
