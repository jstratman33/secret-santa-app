import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupService } from '../services/group.service';
import { InviteService } from '../services/invite.service';
import { Group } from '../models/group';
import { Invite } from '../models/invite';

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
  constructor(private InviteService: InviteService,
    private GroupService: GroupService) {
    this.AddMember();
   }

  ngOnInit() {
  }

  AddMember(): void{
    this.Members.push({
      id: Date.now(),
      email: ""
    });
  }

  SubmitForm(): void{
    const Event: Group={
      id: 0,
      adminId: 2,
      description: this.EventTitle,
      listDeadline: this.ListDeadline,
      exchangeTime: this.ExchangeTime
    }
    console.log(JSON.stringify(Event));
    this.GroupService.create(Event).subscribe(res => {
      console.log(JSON.stringify(res));
    });
    this.Members.forEach(x=>{
      const Invite: Invite={
        id: 0,
        groupId: 4, //add return groupId later
        emailAddress: x.email,
        hash: ""
      };
      this.InviteService.create(Invite).subscribe(res => {
        console.log(JSON.stringify(res));
      });
    });
  }
}
