import { Component, OnInit } from '@angular/core';
import { AuthService, SocialUser } from 'angularx-social-login';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'secret-santa-app-ng';
  user: SocialUser;
  isLoggedIn: boolean = false;

  constructor(private authService: AuthService,
    private userService: UserService) { }

  ngOnInit(): void {
    this.authService.authState.subscribe((user) => {
      this.user = user;
      this.isLoggedIn = (user != null);
      if (this.isLoggedIn) {
        this.userService.handleUserLogin(user);
      }
    });
    console.log('user: ', this.user);
  }
}
