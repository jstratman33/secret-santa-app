import { Component, OnInit } from '@angular/core';
import { GroupService } from '../services/group.service';
import { Group } from '../models/group';
import { Invite } from '../models/invite';
import { InviteService } from '../services/invite.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  constructor(
    private groupService: GroupService,
    private inviteService: InviteService) { }

  ngOnInit() {
  }

  createGroup(): void {
    const group: Group = {
      id: 0,
      adminId: 2,
      description: 'Angular Test Group',
      listDeadline: '2019-05-01',
      exchangeTime: '2019-05-02'
    };
    this.groupService.create(group).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  getAllGroups(): void {
    this.groupService.getAllByUserId(2).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  getOneGroup(): void {
    this.groupService.getOne(6).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  updateGroup(): void {
    const group: Group = {
      id: 6,
      adminId: 2,
      description: 'updated Test Group',
      listDeadline: '2019-05-15',
      exchangeTime: '2019-05-18'
    };
    this.groupService.update(group).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  deleteGroup(): void {
    const id: number = 6;
    this.groupService.delete(id).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  createInvite(): void {
    const invite: Invite = {
      id: 0,
      groupId: 4,
      emailAddress: 'stratmanmedia@gmail.com',
      hash: ''
    };
    this.inviteService.create(invite).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  sendInvite(): void {
    const invite: Invite = {
      id: 0,
      groupId: 4,
      emailAddress: 'stratmanmedia@gmail.com',
      hash: ''
    };
    this.inviteService.send(invite).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  getOneInvite(): void {
    const emailAddress = 'stratmanmedia@gmail.com';
    const hash = '';
    this.inviteService.getOne(emailAddress, hash).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  deleteInvite(): void {
    const id = 3;
    this.inviteService.delete(id).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }
}
