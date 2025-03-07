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

  getCity(id: number): Observable<City> {
    const url = `${this.apiUrl}${id}`;
   
    return this.http.get<City>(url);
  }

  getCitiesByRegion(regionId: number): Observable<City[]> {
    const url = `${this.apiUrl}region/${regionId}`;
    return this.http.get<City[]>(url);
  }
}
