import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SportManagementComponent } from './sport-management/sport-management.component';
import { SportEditComponent } from './sport-edit/sport-edit.component';
import { SharedModule } from '../shared/shared.module';
import { SportsRoutingModule } from './sports-routing.module';
import { SportDefaultComponent } from './sport-default/sport-default.component';

@NgModule({
  declarations: [
    SportManagementComponent,
    SportEditComponent,
    SportDefaultComponent],
  imports: [
    SharedModule,
    SportsRoutingModule
  ],
  bootstrap: [SportEditComponent]
})
export class SportsModule { }
