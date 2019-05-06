import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { GroupService } from 'c:/Users/sward_000/Documents/SecretSantaWorkspace/secret-santa-app-ng/src/app/services/group.service';
import { Group } from 'c:/Users/sward_000/Documents/SecretSantaWorkspace/secret-santa-app-ng/src/app/models/group';
import { List } from '../models/list';

@Component({
  selector: 'app-create-list',
  templateUrl: './create-list.component.html',
  styleUrls: ['./create-list.component.css']
})
export class CreateListComponent implements OnInit {
  private WishList=[];
  constructor() {
    this.AddList();
   }

  ngOnInit() {
  }
  AddList(): void{
    this.WishList.push({
      id: Date.now(),
      item: ""
    });
  }
}
