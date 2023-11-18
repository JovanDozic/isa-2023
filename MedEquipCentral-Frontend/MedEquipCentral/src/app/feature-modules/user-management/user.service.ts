import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../user-management/model/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'https://localhost:7209/api/user';

  constructor(private http: HttpClient) { }

  getAllRegistered(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl + '/getAllRegistered');
  }

  addToCompany(userId: number, companyId: number): Observable<User> {
    return this.http.patch<User>(this.apiUrl + '/' + userId + '/addToCompany/' + companyId, null);
  }

  removeFromCompany(userId: number): Observable<User> {
    return this.http.patch<User>(this.apiUrl + '/' + userId + '/removeFromCompany', null);
  }

}
