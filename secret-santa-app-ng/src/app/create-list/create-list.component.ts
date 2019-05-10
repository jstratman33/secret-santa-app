import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupService } from '../services/group.service';
import { Group } from '../models/group';
import { List } from '../models/list';
import { ListService } from '../services/list.service';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-create-list',
  templateUrl: './create-list.component.html',
  styleUrls: ['./create-list.component.css']
})
export class CreateListComponent implements OnInit {
  private WishList=[];
  currentUser: User=null;
  Groups: Group[]=[];
  selectedGroup: number=-1;
  constructor(private listService: ListService,
    private userService: UserService,
    private groupService: GroupService) {
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
     this.WishList.push({
       id: Date.now(),
       item: ""
     });
  }
  SubmitList(): void{
    this.WishList.forEach(x=>{
      const List: List={
          id: 0,
          ownerId: this.currentUser.id,
          santaId: 0,
          groupId: this.selectedGroup,
          name: this.currentUser.name,
          isPrimary: true,
          items: [
            {
              id: 0,
              listId: 0,
              description: x.item,
              isPurchased: false
            },
            {
              id: 0,
              listId: 0,
              description: x.item,
              isPurchased: false
            }
          ]
        }  
    });
  }
}
