import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';
import { GLOBAL } from '../configuration/configuration.global';

@Injectable({
  providedIn: 'root' // This decorator ensures that CityService is provided throughout the application.
})
export class CityService {

  constructor(private http: HttpClient) {}

  /**
   * Fetches a city by its ID from the API.
   * 
   * @param id The ID of the city to retrieve.
   * @returns An observable containing the city details.
   */
  getCityById(id: number): Observable<City> {
    // Constructs the URL for the specific city by its ID.
    const url = `${GLOBAL.apiBaseUrl}/cities/${id}`;
    
    // Sends a GET request to fetch the city by its ID and returns it as an observable.
    return this.http.get<City>(url);
  }

  /**
   * Fetches cities for a specific region by the region ID.
   * 
   * @param regionId The ID of the region whose cities are to be fetched.
   * @returns An observable containing an array of cities within that region.
   */
  getCitiesByRegion(regionId: number): Observable<City[]> {
    // Constructs the URL for fetching cities by the region ID.
    const url = `${GLOBAL.apiBaseUrl}/cities/region/${regionId}`;
    
    // Sends a GET request to the API to get all cities for the specified region and returns them as an observable.
    return this.http.get<City[]>(url);
  }
}
