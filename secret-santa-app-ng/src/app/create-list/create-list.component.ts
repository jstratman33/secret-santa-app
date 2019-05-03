import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupService } from '../services/group.service';
import { Group } from '../models/group';
import { List } from '../models/list';

@Component({
  selector: 'app-create-list',
  templateUrl: './create-list.component.html',
  styleUrls: ['./create-list.component.css']
})
export class CreateListComponent implements OnInit {
  private WishList=[];
  constructor(private GroupService: GroupService) {
    this.AddList();
   }

  ngOnInit() {
  }
  AddList(): void{
    // this.WishList.push({
    //   id: Date.now(),
    //   item: ""
    // });
  }
  SubmitForm(): void{
    // this.WishList.forEach(x=>{
    //   const Items: List={
    //     id: 0,
    //     item: ""
    //   };
    // });
  }
}
