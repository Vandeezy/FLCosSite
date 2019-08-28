import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import {SportManagementComponent} from './sport-management/sport-management.component';
import {SportEditComponent} from './sport-edit/sport-edit.component';
import {SportDefaultComponent} from './sport-default/sport-default.component';
const routes: Routes = [
  {
    path: '',
    component: SportManagementComponent,
    data: {
      title: "Sports"
    },
    // children: [
    //   {
    //     path: 'edit:id',
    //     component: SportEditComponent,
    //     data: {
    //       title: "Sports Edit"
    //     }
    //   },
    //   {
    //     path: 'add',
    //     component: SportEditComponent,
    //     data: {
    //       title: "Sports Add"
    //     }
    //   },
    //   {
    //     path: 'sports',
    //     component: SportManagementComponent,
    //     data: {
    //       title: "Sports"
    //     }
    //   },
    //   // {
    //   //   path: '',
    //   //   redirectTo: 'sports',
    //   //   pathMatch: 'full'
    //   // }
    // ]
  },
  {
    path: 'add',
    component: SportEditComponent,
    data: {
      title: "Sports Add"
    }
  },
  {
    path: 'edit/:id',
    component: SportEditComponent,
    data: {
      title: "Sports Edit"
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SportsRoutingModule { }
