import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GLOBAL } from '../configuration/configuration.global';

@Injectable({
  providedIn: 'root' // This decorator makes the PictureService available throughout the application.
})
export class PictureService {

  constructor(private http: HttpClient) { }

  /**
   * Fetches a picture by its ID from the API.
   * 
   * @param id The ID of the picture to retrieve.
   * @returns An observable containing the image in base64 format.
   */
  getById(id: number): Observable<{ imageBase64: string }> {
    // Constructs the URL for the specific picture by its ID.
    const url = `${GLOBAL.apiBaseUrl}/pictures/${id}`;
    
    // Sends a GET request to fetch the image by ID and returns it as an observable.
    return this.http.get<{ imageBase64: string }>(url);
  }

  /**
   * Fetches the picture IDs for a specific region.
   * 
   * @param id The ID of the region whose pictures we want to retrieve.
   * @returns An observable containing an array of picture IDs.
   */
  getByRegionId(id: number): Observable<{ id: number[] }> {
    // Constructs the URL for fetching picture IDs by region ID.
    const url = `${GLOBAL.apiBaseUrl}/pictures/region/${id}`;
    
    // Sends a GET request to the API and returns the array of picture IDs as an observable.
    return this.http.get<{ id: number[] }>(url);
  }
}
