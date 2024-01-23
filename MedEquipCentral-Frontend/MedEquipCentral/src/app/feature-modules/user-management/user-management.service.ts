import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../shared/environment";
import { User } from "../../core/auth/model/user.model";
import { Appointment } from "../company-management/model/appointment.model";
import { Company } from "../company-management/model/company.model";
import { Equipment } from "../company-management/model/equipment.model";

@Injectable({
    providedIn: 'root'
})
export class UserManagementService {

    private apiUrl = environment.apiHost;

    constructor(private http: HttpClient) { }

    getUserById(id?: number): Observable<User> {
        return this.http.get<User>(this.apiUrl + 'user' + '/getById/' + id);
    }

    update(user: User): Observable<User> {
        return this.http.put<any>(this.apiUrl + 'user' + '/update/', user);
    }

    getAllRegistered(): Observable<User[]> {
        return this.http.get<User[]>(this.apiUrl + 'user' + '/getAllRegistered');
    }

    getAllSystemAdmins(): Observable<User[]> {
        return this.http.get<User[]>(this.apiUrl + 'user' + '/getAllSystemAdmins');
    }

    addToCompany(userId: number, companyId: number): Observable<User> {
        return this.http.patch<User>(this.apiUrl + 'user' + '/' + userId + '/addToCompany/' + companyId, null);
    }

    removeFromCompany(userId: number): Observable<User> {
        return this.http.patch<User>(this.apiUrl + 'user' + '/' + userId + '/removeFromCompany', null);
    }

    addSystemAdmin(userId: number): Observable<User> {
        return this.http.patch<any>(this.apiUrl + 'user' + "/" + userId + "/addSystemAdmin", null);
    }

    removeSystemAdmin(userId: number): Observable<User> {
        return this.http.patch<any>(this.apiUrl + 'user' + "/" + userId + "/removeSystemAdmin", null);
    }

    getAppointment(appointmentId: number) : Observable<Appointment> {
        return this.http.get<Appointment>(this.apiUrl + "appointment/getById/" + appointmentId);
    }

    getCompany(id: number) : Observable<Company> {
        return this.http.get<Company>(this.apiUrl + 'company/getById/' + id);
    }

    getEquipment(id: number) : Observable<Equipment> {
        return this.http.get<Equipment>(this.apiUrl + 'equipment/getById/' + id);
    }

    getAllUserAppointments(obj: any) : Observable<any> {
        return this.http.post<any>(this.apiUrl + 'appointment/getAllUsersAppointments/', obj);
    }

    changePassword(id: number, newPassword: string): Observable<any> {
        const queryParams = new HttpParams().set('newPassword', newPassword);
        return this.http.patch<any>(this.apiUrl + 'user/changePassword/' + id, null, { params: queryParams });
    }

    getAllWithReservation(companyId: number): Observable<User[]> {
        return this.http.get<User[]>(this.apiUrl + 'user/getUsersWithReservation/' + companyId);
    }
}