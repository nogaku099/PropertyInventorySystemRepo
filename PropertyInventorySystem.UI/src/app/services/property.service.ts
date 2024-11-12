import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Property, PaginatedProperties, PropertyContact, PaginatedPropertiesContacts } from '../models/property.model';

const baseUrl = 'https://localhost:7022/api/Property';
@Injectable({
  providedIn: 'root'
})
export class PropertyService {

  constructor(private http: HttpClient) { }

  getAll(pageNumber: number = 1, pageSize: number = 5): Observable<PaginatedProperties> {
    const params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());
      return this.http.get<PaginatedProperties>(`${baseUrl}`, { 
        params,
        responseType: 'json'  // Explicitly set responseType to JSON
      });
  }

  get(id: any): Observable<Property> {
    return this.http.get<Property>(`${baseUrl}/${id}`);
  }

  getAllPropertiesContacts(pageNumber: number = 1, pageSize: number = 5): Observable<PaginatedPropertiesContacts> {
    const params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());
      return this.http.get<PaginatedPropertiesContacts>(`${baseUrl}`, { 
        params,
        responseType: 'json'  // Explicitly set responseType to JSON
      });
  }

  getPropertyContact(id: any): Observable<PropertyContact> {
    return this.http.get<PropertyContact>(`${baseUrl}/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${baseUrl}/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }

  deleteAll(): Observable<any> {
    return this.http.delete(baseUrl);
  }

  // findByTitle(title: any): Observable<Property[]> {
  //   return this.http.get<Property[]>(`${baseUrl}?title=${title}`);
  // }
}
