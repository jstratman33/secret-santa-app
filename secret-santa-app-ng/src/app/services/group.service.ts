import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Group } from '../models/group';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GroupService {

  private url: string = environment.apiBaseUrl + '/api/groups';

  constructor(private http: HttpClient) { }

  create(group: Group): Observable<any> {
    return this.http.post(this.url, group);
  }

  getAllByUserId(id: number): Observable<Group[]> {
    const url = this.url + `/foruser/${id}`;
    return this.http.get<Group[]>(url);
  }

  getOne(id: number): Observable<Group> {
    const url = this.url + `/${id}`;
    return this.http.get<Group>(url);
  }

  update(group: Group): Observable<any> {
    const url = this.url + `/${group.id}`;
    return this.http.put(url, group);
  }

  delete(id: number): Observable<any> {
    const url = this.url + `/${id}`;
    return this.http.delete(url);
  }
}
