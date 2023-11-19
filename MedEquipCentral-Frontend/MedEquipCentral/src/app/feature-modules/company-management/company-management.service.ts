import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Company } from './model/company.model';
import { User } from '../user-management/model/user.model';
import { Equipment } from './model/equipment.model';
import { Appointment } from './model/appointment.model';

@Injectable({
  providedIn: 'root'
})
export class CompanyManagementService {

  private apiUrl = 'https://localhost:7209/api/company';

  constructor(private http: HttpClient) { }

  addCompany(company: Company): Observable<Company> {
    return this.http.post<Company>(this.apiUrl, company);
  }

  getCompany(id: number): Observable<Company> {
    return this.http.get<Company>(this.apiUrl + '/getById/' + id);
  }

  getCompanyAdmins(copmanyId: number): Observable<User[]> {
    return this.http.get<User[]>('https://localhost:7209/api/user/getAllByCompanyId/' + copmanyId);
  }

  updateCompany(company: Company): Observable<Company> {
    return this.http.put<Company>(this.apiUrl, company)
  }

  getAll(): Observable<any> {
    return this.http.get<any>(this.apiUrl + '/getAll');
  }

  getAllBySearch(dataIn: any): Observable<any> {
    return this.http.post<any>(this.apiUrl + '/getAllBySearch', dataIn);
  }

  removeCompanyAdmin(user: User): Observable<User> {
    return this.http.put<User>('https://localhost:7209/api/user/' + user.id + '/removeAdmin', user);
  }

  getEquipment(companyId: number): Observable<Equipment[]> {
    return this.http.get<Equipment[]>('https://localhost:7209/api/equipment/getAllForCompany/' + companyId);
  }

  makeAppointment(appointment: Appointment): Observable<Appointment> {
    return this.http.post<Appointment>('https://localhost:7209/api/appointment/', appointment)
  }
}
