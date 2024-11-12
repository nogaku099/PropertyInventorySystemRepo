import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Property } from '../models/property.model';

const baseUrl = 'https://localhost:7022/api/Property';
@Injectable({
  providedIn: 'root'
})
export class PropertyService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Property[]> {
    return this.http.get<Property[]>(baseUrl);
  }

  get(id: any): Observable<Property> {
    return this.http.get<Property>(`${baseUrl}/${id}`);
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
