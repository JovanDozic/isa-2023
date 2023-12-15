import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../shared/environment";
import { observableToBeFn } from "rxjs/internal/testing/TestScheduler";
import { User } from "../../core/auth/model/user.model";

@Injectable({
    providedIn: 'root'
})
export class UserManagementService {

    private apiUrl = environment.apiHost + 'user';

    constructor(private http: HttpClient) { }

    getUserById(id: number): Observable<User> {
        return this.http.get<User>(this.apiUrl + '/getById/' + id);
    }

    update(user: User): Observable<User> {
        return this.http.put<any>(this.apiUrl + '/update/', user);
    }

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

    addSystemAdmin(userId: number): Observable<User> {
        return this.http.patch<any>(this.apiUrl + "/" + userId + "/addSystemAdmin", null);
    }

    removeSystemAdmin(userId: number): Observable<User> {
        return this.http.patch<any>(this.apiUrl + "/" + userId + "/removeSystemAdmin", null);
    }
}