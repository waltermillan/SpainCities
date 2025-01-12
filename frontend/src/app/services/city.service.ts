import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';

@Injectable({
  providedIn: 'root',
})
export class CityService {
  private apiUrlCity = 'http://localhost:5184/api/City/Get?id=';
  private apiUrlCitiesByRegion = 'http://localhost:5184/api/City/GetByRegion/';  // Nueva URL para obtener ciudades por región

  constructor(private http: HttpClient) {}

  // Métodos existentes para obtener ciudad, región y provincia
  getCity(id: number): Observable<City> {
    const url = `${this.apiUrlCity}${id}`;
    //console.log(`URL de getCity: ${url}`);
    return this.http.get<City>(url);
  }

  // Nuevo método para obtener las ciudades por región
  getCitiesByRegion(regionId: number): Observable<City[]> {
    const url = `${this.apiUrlCitiesByRegion}${regionId}`;
    return this.http.get<City[]>(url);  // Esperamos un array de objetos City
  }
}
