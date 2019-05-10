import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { CreateEventComponentComponent } from './create-event-component/create-event-component.component';
import { CreateListComponent } from './create-list/create-list.component';
import { CreateKidListComponent } from './create-kid-list/create-kid-list.component';
import { ViewListComponent } from './view-list/view-list.component';
import { ViewSantaComponent } from './view-santa/view-santa.component';
import { EditListComponent } from './edit-list/edit-list.component';
import { TestComponent } from './test/test.component';
import { GroupListComponent } from './group-list/group-list.component';


const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'test',
    component: TestComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'test',
    component: TestComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'create_event',
    component: CreateEventComponentComponent
  },
  {
    path: 'create_list',
    component: CreateListComponent
  },
  {
    path: 'create_kid_list',
    component: CreateKidListComponent
  },
  {
    path: 'view_list',
    component: ViewListComponent
  },
  {
    path: 'view_santa',
    component: ViewSantaComponent
  },
  {
    path: 'group-list',
    component: GroupListComponent
  },
  {
    path: 'edit_list',
    component: EditListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
