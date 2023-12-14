import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "./model/user.model";
import { environment } from "../../shared/environment";

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
}