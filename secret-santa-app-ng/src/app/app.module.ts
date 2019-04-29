import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider, FacebookLoginProvider, LinkedInLoginProvider} from 'angularx-social-login';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserService } from './services/user.service';
import { TestComponent } from './test/test.component';
import { GroupService } from './services/group.service';
import { InviteService } from './services/invite.service';
import { CreateEventComponentComponent } from './create-event-component/create-event-component.component';
import { CreateListComponent } from './create-list/create-list.component';
import { CreateKidListComponent } from './create-kid-list/create-kid-list.component';
import { ViewListComponent } from './view-list/view-list.component';
import { ViewSantaComponent } from './view-santa/view-santa.component';
import { EditListComponent } from './edit-list/edit-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

const config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider('Google-OAuth-Client-Id')
  },
  {
    id: FacebookLoginProvider.PROVIDER_ID,
    provider: new FacebookLoginProvider('336416786991463')
  },
  {
    id: LinkedInLoginProvider.PROVIDER_ID,
    provider: new LinkedInLoginProvider('LinkedIn-client-Id', false, 'en_US')
  }
]);

export function provideConfig() {
  return config;
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    CreateEventComponentComponent,
    CreateListComponent,
    CreateKidListComponent,
    ViewListComponent,
    ViewSantaComponent,
    EditListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    SocialLoginModule
  ],
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    },
    UserService,
    GroupService,
    InviteService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
