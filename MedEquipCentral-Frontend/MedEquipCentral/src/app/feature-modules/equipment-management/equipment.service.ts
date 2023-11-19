import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {
  
  private apiUrl = 'https://localhost:7209/api/equipment';

  constructor(private http: HttpClient) { }

  getEquipment() {
    return this.http.get(this.apiUrl + '/getAll/');
  }

  getEquipmentTypes() {
    return this.http.get(this.apiUrl + 'types/getAll/');
  }
}
