import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupService } from '../services/group.service';
import { Group } from '../models/group';
import { List } from '../models/list';
import { ListService } from '../services/list.service';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { ListItem } from '../models/list-item';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-list',
  templateUrl: './create-list.component.html',
  styleUrls: ['./create-list.component.css']
})
export class CreateListComponent implements OnInit {
  WishList: ListItem[]=[];
  currentUser: User=null;
  Groups: Group[]=[];
  selectedGroup: number=-1;
  constructor(private listService: ListService,
    private userService: UserService,
    private groupService: GroupService,
    private router: Router) {
    this.AddList();
   }

  ngOnInit() {
    this.userService.currentUser.subscribe((user: User)=>{
    this.currentUser=user;
    this.groupService.getAllByUserId(user.id).subscribe((groups: Group[])=>{
      this.Groups=groups;
    })
    });
  }
  AddList(): void{
     this.WishList.push(<ListItem>{
       Id: 0,
       Description: ""
     });
  }
  SubmitList(): void{
    const List = <List>{
        OwnerId: this.currentUser.id,
        GroupId: this.selectedGroup,
        Name: this.currentUser.name,
        IsPrimary: true,
        Items: this.WishList
    }
    console.log(List);
    this.listService.create(List).subscribe(res => {
      console.log(JSON.stringify(res));
      this.router.navigateByUrl(`/group-list/${this.selectedGroup}`);
    });
  }
}
