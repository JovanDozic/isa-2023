import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Company } from './model/company.model';

@Injectable({
  providedIn: 'root'
})
export class CompanyManagementService {

  private apiUrl = 'https://localhost:7209/api/company';

  constructor(private http: HttpClient) { }

  addCompany(company: Company): Observable<Company> {
    return this.http.post<Company>(this.apiUrl, company);
  }
}
