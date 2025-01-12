import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Province } from '../models/province.model';

@Injectable({
  providedIn: 'root',
})
export class ProvinceService {
  private apiUrlProvince = 'http://localhost:5184/api/Province/Get?id=';
  private apiUrlProvincesByRegion = 'http://localhost:5184/api/Province/GetAllByRegion/';

  constructor(private http: HttpClient) {}

  getProvince(id: number): Observable<Province> {
    const url = `${this.apiUrlProvince}${id}`;
    //console.log(`URL de getProvince: ${url}`);
    return this.http.get<Province>(url);
  }

  // Método para obtener las provincias por región
  getProvincesByRegion(regionId: number): Observable<any> {
    const url = `${this.apiUrlProvincesByRegion}${regionId}`;
    //console.log(`URL de getProvincesByRegion: ${url}`);
    return this.http.get<any>(url);  // Esperamos un objeto con la propiedad "provinces" que es un array
  }
}
