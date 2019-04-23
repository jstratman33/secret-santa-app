import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SocialUser } from 'angularx-social-login';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private env = environment;

  constructor(private http: HttpClient) {}

  handleUserLogin(user: SocialUser): void {
    const url = this.env.apiBaseUrl + '/api/users';
    const body = {
      EmailAddress: user.email,
      Name: user.name
    };
    this.http.post(url, body).subscribe();
  }
}
