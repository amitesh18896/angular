import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { event } from '../models/event.model';

const baseUrl = 'https://localhost:44343/api/Event';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<event[]> {
    return this.http.get<event[]>(baseUrl);
  }
  getEventTypeOptions():Observable<event[]> {
    return this.http.get<event[]>(baseUrl);
  }
  get(id: any): Observable<event> {
    return this.http.get<event>(`${baseUrl}/${id}`);
  }
  getNextId(): Observable<number> {
    return this.http.get<number>(`${baseUrl}/getNextId`);
  }
  create(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }
  saveEvent(data: any): Observable<any> {
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

  findByTitle(title: any): Observable<event[]> {
    return this.http.get<event[]>(`${baseUrl}?title=${title}`);
  }
}
