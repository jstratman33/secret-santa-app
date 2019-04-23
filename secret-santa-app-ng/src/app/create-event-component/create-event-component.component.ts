import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-create-event-component',
  templateUrl: './create-event-component.component.html',
  styleUrls: ['./create-event-component.component.css']
})
export class CreateEventComponentComponent implements OnInit {
  private Members: string[] = [""];
  constructor() { }

  ngOnInit() {
  }
  AddMember(): void{
    this.Members.push("");
  }
}
