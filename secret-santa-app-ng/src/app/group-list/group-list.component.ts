import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { List } from '../models/list';
import { ListService } from '../services/list.service';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-group-list',
  templateUrl: './group-list.component.html',
  styleUrls: ['./group-list.component.css']
})
export class GroupListComponent implements OnInit {

  private groupId: number;
  private currentUser: User;
  userLists: List[];

  constructor(private route: ActivatedRoute,
    private listService: ListService,
    private userService: UserService) { }

  ngOnInit() {
    this.groupId = +this.route.snapshot.paramMap.get('id');
    this.userService.currentUser.subscribe((user: User) => {
      this.currentUser = user;
      this.listService.getAllByOwnerId(user.id);
    });
  }
}
