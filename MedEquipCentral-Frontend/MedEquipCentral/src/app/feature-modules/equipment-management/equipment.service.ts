import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../shared/environment';
import { Observable } from 'rxjs';
import { EquipmentType } from '../company-management/model/equipment-type.model';
import { Equipment } from '../company-management/model/equipment.model';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {
  
  private apiUrl = environment.apiHost + 'equipment';

  constructor(private http: HttpClient) { }

  getEquipment() {
    return this.http.get(this.apiUrl + '/getAll/');
  }

  getEquipmentTypes(): Observable<EquipmentType[]> {
    return this.http.get<EquipmentType[]>(this.apiUrl + 'types/getAll/');
  }

  getEquipmentForCompany(companyId: number){
    return this.http.get(this.apiUrl + '/getAllForCompany/' + companyId);
  }

  addEquipment(equipment: Equipment): Observable<Equipment> {
    return this.http.post<Equipment>(this.apiUrl, equipment);
  }

  updateEquipment(equipment: Equipment): Observable<Equipment> {
    return this.http.put<Equipment>(this.apiUrl, equipment);
  }

  delete(equipmentId: number): Observable<boolean> {
    return this.http.delete<boolean>(this.apiUrl + '/' + equipmentId);
  }
}
