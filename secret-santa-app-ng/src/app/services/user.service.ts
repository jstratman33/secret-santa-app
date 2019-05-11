import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SocialUser } from 'angularx-social-login';
import { environment } from '../../environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private env = environment;
  private currentUserSubject: BehaviorSubject<User>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(null);
  }

  get currentUser(): Observable<User> {
    return this.currentUserSubject.asObservable();
  }

  handleUserLogin(user: SocialUser): void {
    console.log('socialUser: ', user);
    const url = this.env.apiBaseUrl + '/api/users';
    const body = <User>{
      socialId: user.id,
      emailAddress: user.email,
      name: user.name
    };
    this.http.post(url, body).subscribe((user: User) => {
      this.currentUserSubject.next(user);
    });
  }
}
