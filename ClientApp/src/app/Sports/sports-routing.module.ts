import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import {SportManagementComponent} from './sport-management/sport-management.component';
import {SportEditComponent} from './sport-edit/sport-edit.component';

const routes: Routes = [
  {
    path: '',
    component: SportManagementComponent,
    data: {
      title: "Sports"
    }
  },
  {
    path: 'sports/edit:id',
    component: SportEditComponent,
    data: {
      title: "Sports Edit"
    }
  },
  {
    path: 'sports/add',
    component: SportEditComponent,
    data: {
      title: "Sports Add"
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SportsRoutingModule { }
