import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-create-list',
  templateUrl: './create-list.component.html',
  styleUrls: ['./create-list.component.css']
})
export class CreateListComponent implements OnInit {
  private WishList: string[] = [""];
  constructor() { }

  ngOnInit() {
  }
  AddList(): void{
    this.WishList.push("");
  }
}
