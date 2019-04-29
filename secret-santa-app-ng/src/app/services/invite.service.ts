import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Invite } from '../models/invite';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InviteService {

  private url: string = environment.apiBaseUrl + '/api/invites';

  constructor(private http: HttpClient) { }

  create(invite: Invite): Observable<any> {
    return this.http.post(this.url, invite);
  }

  send(invite: Invite): Observable<any> {
    const url: string = this.url + `/send`;
    return this.http.post(url, invite);
  }

  getOne(email: string, hash: string): Observable<any> {
    const url: string = this.url + `?email=${email}&hash=${hash}`;
    return this.http.get(url);
  }

  delete(id: number) {
    const url: string = this.url + `/${id}`;
    return this.http.delete(url);
  }
}
