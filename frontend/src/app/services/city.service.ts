import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';

@Injectable({
  providedIn: 'root',
})
export class CityService {
  private apiUrl = 'http://localhost:5184/api/cities/';

  constructor(private http: HttpClient) {}

  // Métodos existentes para obtener ciudad, región y provincia
  getCity(id: number): Observable<City> {
    const url = `${this.apiUrl}${id}`;
   
    return this.http.get<City>(url);
  }

  // Nuevo método para obtener las ciudades por región
  getCitiesByRegion(regionId: number): Observable<City[]> {
    const url = `${this.apiUrl}region/${regionId}`;
    return this.http.get<City[]>(url);  // Esperamos un array de objetos City
  }
}
