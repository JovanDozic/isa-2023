import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../shared/environment';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {
  
  private apiUrl = environment.apiHost + 'equipment';

  constructor(private http: HttpClient) { }

  getEquipment() {
    return this.http.get(this.apiUrl + '/getAll/');
  }

  getEquipmentTypes() {
    return this.http.get(this.apiUrl + 'types/getAll/');
  }
}
