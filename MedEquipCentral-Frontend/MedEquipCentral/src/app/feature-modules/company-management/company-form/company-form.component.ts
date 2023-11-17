import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyManagementService } from '../company-management.service';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrl: './company-form.component.css'
})
export class CompanyFormComponent implements OnInit {

  companyForm!: FormGroup;

  constructor(private fb: FormBuilder, private companyService: CompanyManagementService) { }

  ngOnInit(): void {
    this.companyForm = this.fb.group({
      name: ['', Validators.required],
      locationId: ['', Validators.required],
      location: this.fb.group({
        latitude: ['', Validators.required],
        longitude: ['', Validators.required],
        street: ['', Validators.required],
        streetNumber: ['', Validators.required],
        city: ['', Validators.required],
        zip: ['', Validators.required],
        country: ['', Validators.required],
      }),
      description: [''],
      rating: ['', Validators.required]
    });
  }

  addCompany() {
    console.log("nes se desilo");
    console.log(this.companyForm.value);
    if (this.companyForm.valid) {
      this.companyService.addCompany(this.companyForm.value).subscribe(
        (response) => console.log(response),
        (error) => console.log(error)
      );
    }
  }

}
