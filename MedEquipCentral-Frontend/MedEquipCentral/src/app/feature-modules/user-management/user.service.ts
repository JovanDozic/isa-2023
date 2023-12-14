import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../user-management/model/user.model';
import { environment } from '../../shared/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = environment.apiHost + 'user';

  constructor(private http: HttpClient) { }

  getAllRegistered(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl + '/getAllRegistered');
  }

  getAllSystemAdmins(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl + '/getAllSystemAdmins');
  }

  addToCompany(userId: number, companyId: number): Observable<User> {
    return this.http.patch<User>(this.apiUrl + '/' + userId + '/addToCompany/' + companyId, null);
  }

  removeFromCompany(userId: number): Observable<User> {
    return this.http.patch<User>(this.apiUrl + '/' + userId + '/removeFromCompany', null);
  }

}
