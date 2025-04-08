import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Province } from '../models/province.model';
import { GLOBAL } from '../configuration/configuration.global';

@Injectable({
  providedIn: 'root', // This makes the ProvinceService available across the entire application.
})
export class ProvinceService {

  constructor(private http: HttpClient) {}

  /**
   * Fetches a province by its ID from the API.
   * 
   * @param id The ID of the province to retrieve.
   * @returns An observable containing the province data.
   */
  getProvince(id: number): Observable<Province> {
    // Construct the URL for the province API endpoint using the given ID.
    const url = `${GLOBAL.apiBaseUrl}/provinces/${id}`;
    
    // Sends a GET request to the API and returns an observable with the province data.
    return this.http.get<Province>(url);
  }

  /**
   * Fetches the provinces for a specific region by the region's ID.
   * 
   * @param regionId The ID of the region whose provinces we want to fetch.
   * @returns An observable containing a list of provinces in that region.
   */
  getProvincesByRegion(regionId: number): Observable<any> {
    // Construct the URL for the provinces of a specific region.
    const url = `${GLOBAL.apiBaseUrl}/provinces/region/${regionId}`;
    
    // Sends a GET request to the API and returns the observable with the provinces data.
    return this.http.get<any>(url);
  }
}
