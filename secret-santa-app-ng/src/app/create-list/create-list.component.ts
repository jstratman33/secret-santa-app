import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupService } from '../services/group.service';
import { Group } from '../models/group';
import { List } from '../models/list';
import { ListService } from 'c:/Users/sward_000/Documents/SecretSantaWorkspace/secret-santa-app-ng/src/app/services/list.service'
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-create-list',
  templateUrl: './create-list.component.html',
  styleUrls: ['./create-list.component.css']
})
export class CreateListComponent implements OnInit {
  private WishList=[];
  currentUser: User=null;
  Groups: Group[]=[];
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
          groupId: this.groupId,
          name: 'User\'s Wish List',
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
