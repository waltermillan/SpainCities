import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  private apiUrl = 'http://localhost:5184/api/Image/Get?id=';

  constructor(private http: HttpClient) { }

  // Cambiado para recibir un objeto con base64Image
  getImage(id: number): Observable<{ imageBase64: string }> {
    //return this.http.get<{ imageBase64: string }>(`${this.apiUrl}${id}`);
  const url = `${this.apiUrl}${id}`;
  //console.log('URL de la petición:', url);
  return this.http.get<{ imageBase64: string }>(url);
  }
}
