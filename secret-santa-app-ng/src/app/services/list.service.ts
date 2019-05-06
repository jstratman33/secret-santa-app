import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { List } from '../models/list';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ListService {

  private url: string = environment.apiBaseUrl + '/api/lists';

  constructor(private http: HttpClient) { }

  create(list: List): Observable<any> {
    return this.http.post(this.url, list);
  }

  getAllByGroupId(id: number): Observable<List[]> {
    const url = this.url + `/group/${id}`;
    return this.http.get<List[]>(url);
  }

  getAllByOwnerId(id: number): Observable<List[]> {
    const url = this.url + `/owner/${id}`;
    return this.http.get<List[]>(url);
  }

  getOne(id: number): Observable<List> {
    const url = this.url + `/${id}`;
    return this.http.get<List>(url);
  }

  update(list: List): Observable<any> {
    const url = this.url;
    return this.http.put(url, list);
  }

  delete(id: number): Observable<any> {
    const url = this.url + `/${id}`;
    return this.http.delete(url);
  }
}
