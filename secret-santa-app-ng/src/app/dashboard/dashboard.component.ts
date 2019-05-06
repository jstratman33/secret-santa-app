import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { GroupService } from '../services/group.service';
import { Group } from '../models/group';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  currentUser: User = null;
  groups: Group[];

  constructor(private userService: UserService,
    private groupService: GroupService) { }

  ngOnInit() {
    this.userService.currentUser.subscribe((user: User) => {
      this.currentUser = user;
    });

    this.groupService.getAllByUserId(this.currentUser.id).subscribe(res => {
      console.log(JSON.stringify(res));
      this.groups = res;
    });
  }

}
