import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-create-kid-list',
  templateUrl: './create-kid-list.component.html',
  styleUrls: ['./create-kid-list.component.css']
})
export class CreateKidListComponent implements OnInit {
  private WishList: string[] = [""];
  constructor() { }

  ngOnInit() {
  }
  AddList(): void{
    this.WishList.push("");
  }
}
