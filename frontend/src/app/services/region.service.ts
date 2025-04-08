import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Region } from '../models/region.model';
import { GLOBAL } from '../configuration/configuration.global';

@Injectable({
  providedIn: 'root', // This makes the RegionService available across the entire application.
})
export class RegionService {
  constructor(private http: HttpClient) {}

  /**
   * Fetches a region by its ID from the API.
   * 
   * @param id The ID of the region we want to retrieve.
   * @returns An observable containing the region data.
   */
  getRegion(id: number): Observable<Region> {
    // Construct the URL using the base API URL and the region ID.
    const url = `${GLOBAL.apiBaseUrl}/regions/${id}`;
    
    // Sends a GET request to the API and returns the observable of the region data.
    return this.http.get<Region>(url);
  }
}
