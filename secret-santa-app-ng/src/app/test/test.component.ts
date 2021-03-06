import { Component, OnInit } from '@angular/core';
import { GroupService } from '../services/group.service';
import { Group } from '../models/group';
import { Invite } from '../models/invite';
import { InviteService } from '../services/invite.service';
import { ListService } from '../services/list.service';
import { List } from '../models/list';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  userId = 2;
  groupId = 7;
  inviteId = 0;
  listId = 12;
  itemId = 26;

  constructor(
    private groupService: GroupService,
    private inviteService: InviteService,
    private listService: ListService) { }

  ngOnInit() {
  }

  createGroup(): void {
    const group: Group = {
      Id: 0,
      AdminId: this.userId,
      Description: 'Angular Test Group',
      ListDeadline: '2019-05-01',
      ExchangeTime: '2019-05-02'
    };
    this.groupService.create(group).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  getAllGroups(): void {
    this.groupService.getAllByUserId(this.userId).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  getOneGroup(): void {
    this.groupService.getOne(this.groupId).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  updateGroup(): void {
    const group: Group = {
      Id: this.groupId,
      AdminId: this.userId,
      Description: 'updated Test Group',
      ListDeadline: '2019-05-15',
      ExchangeTime: '2019-05-18'
    };
    this.groupService.update(group).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  deleteGroup(): void {
    this.groupService.delete(this.groupId).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  createInvite(): void {
    const invite: Invite = {
      id: 0,
      groupId: this.groupId,
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
      groupId: this.groupId,
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
    this.inviteService.delete(this.inviteId).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  createList(): void {
    const list: List = {
      Id: 0,
      OwnerId: this.userId,
      SantaId: 0,
      GroupId: this.groupId,
      Name: 'Jason\'s Wish List',
      IsPrimary: true,
      Items: [
        {
          Id: 0,
          ListId: 0,
          Description: '60 inch OLED 4K HDR TV',
          IsPurchased: false
        },
        {
          Id: 0,
          ListId: 0,
          Description: 'ASUS ROG 17 inch Laptop',
          IsPurchased: false
        }
      ]
    };
    this.listService.create(list).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  getOneList(): void {
    this.listService.getOne(this.listId).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  getAllListsForGroup(): void {
    this.listService.getAllByGroupId(this.groupId).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }


  getAllListsForOwner(): void {
    this.listService.getAllByOwnerId(this.userId, this.groupId).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  updateList(): void {
    const list: List = {
      Id: this.listId,
      OwnerId: this.userId,
      SantaId: 0,
      GroupId: this.groupId,
      Name: 'Jason\'s TEST Wish List',
      IsPrimary: true,
      Items: [
        {
          Id: this.itemId,
          ListId: this.listId,
          Description: 'TEST 60 inch OLED 4K HDR TV',
          IsPurchased: true
        },
        {
          Id: 0,
          ListId: this.listId,
          Description: 'Gibson Acoustic Guitar',
          IsPurchased: false
        }
      ]
    };
    this.listService.update(list).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }

  deleteList(): void {
    this.listService.delete(this.listId).subscribe(res => {
      console.log(JSON.stringify(res));
    });
  }
}
