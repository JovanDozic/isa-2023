import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyManagementService } from '../company-management.service';
import { Company } from '../model/company.model';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrl: './company-form.component.css'
})
export class CompanyFormComponent implements OnInit, OnChanges {
  @Input() company?: Company;
  @Input() shouldEdit: boolean = false;
  @Output() companyUpdated = new EventEmitter<null>();

  companyForm!: FormGroup;

  constructor(private fb: FormBuilder, private companyService: CompanyManagementService) { }

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
      rating: [0, Validators.required]
    });
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
      console.log("nes se desilo");
      this.companyService.addCompany(this.companyForm.value).subscribe(
        (response) => console.log(response),
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
      }

      this.companyService.updateCompany(editedCompany).subscribe({
        next: resposne => {
          console.log(resposne);
          this.companyUpdated.emit();
        },
        error: err => {
          console.log(err);
        }
      });
    }
  }

}
