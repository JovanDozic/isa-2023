import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Company } from '../model/company.model';
import { CompanyManagementService } from '../company-management.service';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrl: './companies.component.css'
})
export class CompaniesComponent {
  public companies: Company[] = []; 
  public search: string = '';
  public selectedRating: number = 0;
  public ratingOptions: number[] = [0, 1, 2, 3, 4, 5];
  public sortTypes: string[] = ['ASC', 'DESC'];
  public sortType: string = 'ASC';
  public sortBys: string[] = ['Name', 'City', 'Rating'];
  public sortBy: string = '';

  constructor(public companyService: CompanyManagementService) {

  }

  ngOnInit(): void {
    this.companyService.getAll().subscribe({
      next: resposne => {
        console.log(resposne);
        this.companies = resposne;
      },
      error: err => {
        console.log(err);
      }
    })
  }

  searchCompanies() {
    let isAsc = true;
    if(this.sortType === 'DESC')
      isAsc= false;

    let filter = {
      PageInfo: {
        page: 1,
        pageSize: 60
      },
      CompanyFilter: {
        rating: this.selectedRating,
        search: this.search,
        sortBy: this.sortBy,
        isAsc: isAsc
      }
    }
    this.companyService.getAllBySearch(filter).subscribe({
      next: resposne => {
        console.log(resposne);
        this.companies = resposne.result;
      },
      error: err => {
        console.log(err);
      }
    })
  }
}
