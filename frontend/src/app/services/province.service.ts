import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Province } from '../models/province.model';

@Injectable({
  providedIn: 'root',
})
export class ProvinceService {
  private apiUrl = 'http://localhost:5184/api/provinces/';

  constructor(private http: HttpClient) {}

  getProvince(id: number): Observable<Province> {
    const url = `${this.apiUrl}${id}`;

    return this.http.get<Province>(url);
  }

  // Método para obtener las provincias por región
  getProvincesByRegion(regionId: number): Observable<any> {
    const url = `${this.apiUrl}region/${regionId}`;
    return this.http.get<any>(url);
  }
}
