import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sport-management',
  templateUrl: './sport-management.component.html',
  styleUrls: ['./sport-management.component.scss']
})
export class SportManagementComponent implements OnInit {

  constructor() { }
  input: string;
  searchVal: any;
  alertModel: any;
  ngOnInit() {
  }
  enterUp(){
    
  }
}
