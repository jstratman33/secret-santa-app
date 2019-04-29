import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupService } from '../services/group.service';
import { Group } from '../models/group';

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
  constructor(private GroupService: GroupService) {
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
  }
}
