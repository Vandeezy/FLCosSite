import { Component, OnInit } from '@angular/core';
import { SportService } from '../services/sport.service';
import { Sport } from '../models/sport.model';
@Component({
  selector: 'app-sport-management',
  templateUrl: './sport-management.component.html',
  styleUrls: ['./sport-management.component.scss']
})
export class SportManagementComponent implements OnInit {

  constructor(private sportService: SportService) { }
  input: string;
  searchVal: any;
  alertModel: any;
  isAdmin: boolean;
  actionType: any;
  isMultiSelected: any;
  currentlists: Sport[];
  isPanelcollapsed: any;
  
  ngOnInit() {
    this.sportService.getSports("","","").subscribe(s => {
      this.currentlists = s;
    })
  }
  enterUp(){

  }
}
