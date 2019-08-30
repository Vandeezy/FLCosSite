import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgDatepickerModule } from 'ng2-datepicker';
import {NgxPaginationModule} from 'ngx-pagination'; 

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    NgDatepickerModule,
    NgxPaginationModule
  ],
  exports:[
    CommonModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    NgDatepickerModule,
    NgxPaginationModule
  ]
})
export class SharedModule { }
