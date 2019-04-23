import { Component, OnInit } from '@angular/core';
import { GroupService } from '../services/group.service';
import { Group } from '../models/group';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  constructor(private groupService: GroupService) { }

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
}
