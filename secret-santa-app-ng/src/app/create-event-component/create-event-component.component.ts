import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupService } from '../services/group.service';
import { InviteService } from '../services/invite.service';
import { Group } from '../models/group';
import { Invite } from '../models/invite';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { groupBy } from 'rxjs/internal/operators/groupBy';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-event-component',
  templateUrl: './create-event-component.component.html',
  styleUrls: ['./create-event-component.component.css']
})
export class CreateEventComponentComponent implements OnInit {
  private Members=[];
  private EventTitle: string="";
  private ListDeadline: string="";
  private ExchangeTime: string="";
  private currentUser: User;

  constructor(private InviteService: InviteService,
    private GroupService: GroupService,
    private userService: UserService,
    private router: Router) {

    this.AddMember();
   }

  ngOnInit() {
    this.userService.currentUser.subscribe((user: User) => {
      this.currentUser = user;
    });
  }

  AddMember(): void{
    this.Members.push({
      id: Date.now(),
      email: ""
    });
  }

  SubmitForm(): void{
    const Event = <Group>{
      AdminId: this.currentUser.id,
      Description: this.EventTitle,
      ListDeadline: this.ListDeadline,
      ExchangeTime: this.ExchangeTime
    };
    console.log('request: ', Event);
    this.GroupService.create(Event).subscribe((res: Group) => {
      console.log('group response: ', res);
      this.Members.forEach(x=>{
        const Invite = <Invite>{
          groupId: res.Id,
          emailAddress: x.email,
        };
        console.log('invite request: ', Invite);
        this.InviteService.create(Invite).subscribe(inviteRes => {
          console.log('invite response: ', inviteRes);
        });
      });
      this.router.navigateByUrl('/dashboard');
    });
  }
}
