import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PictureService {

  private apiUrl = 'http://localhost:5184/api/pictures/';

  constructor(private http: HttpClient) { }

  getPicture(id: number): Observable<{ imageBase64: string }> {
  const url = `${this.apiUrl}${id}`;
 
  return this.http.get<{ imageBase64: string }>(url);
  }
}
