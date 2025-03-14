import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Region } from '../models/region.model';
import { Province } from '../models/province.model';

@Injectable({
  providedIn: 'root',
})
export class RegionService {
  private apiUrl = 'http://localhost:5184/api/regions/';

  constructor(private http: HttpClient) {}

  getRegion(id: number): Observable<Region> {
    const url = `${this.apiUrl}${id}`;
    
    return this.http.get<Region>(url);
  }
}
