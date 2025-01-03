import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';
import { Region } from '../models/region.model';
import { Province } from '../models/province.model';

@Injectable({
  providedIn: 'root',
})
export class DatosService {
  private apiUrlCity = 'http://localhost:5184/api/City/Get?id=';
  private apiUrlRegion = 'http://localhost:5184/api/Region/Get?id=';
  private apiUrlProvince = 'http://localhost:5184/api/Province/Get?id=';
  private apiUrlProvincesByRegion = 'http://localhost:5184/api/Province/GetAllByRegion/';
  private apiUrlCitiesByRegion = 'http://localhost:5184/api/City/GetByRegion/';  // Nueva URL para obtener ciudades por región

  constructor(private http: HttpClient) {}

  // Métodos existentes para obtener ciudad, región y provincia
  getCity(id: number): Observable<City> {
    const url = `${this.apiUrlCity}${id}`;
    //console.log(`URL de getCity: ${url}`);
    return this.http.get<City>(url);
  }

  getRegion(id: number): Observable<Region> {
    const url = `${this.apiUrlRegion}${id}`;
    //console.log(`URL de getRegion: ${url}`);
    return this.http.get<Region>(url);
  }

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

  // Nuevo método para obtener las ciudades por región
  getCitiesByRegion(regionId: number): Observable<City[]> {
    const url = `${this.apiUrlCitiesByRegion}${regionId}`;
    return this.http.get<City[]>(url);  // Esperamos un array de objetos City
  }
}
