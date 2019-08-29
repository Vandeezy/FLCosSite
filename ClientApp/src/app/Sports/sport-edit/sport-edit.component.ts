import { Component, OnInit } from '@angular/core';
import { Observable, concat, of } from 'rxjs';
import { takeUntil, tap, flatMap, switchMap, map } from 'rxjs/operators';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Sport } from '../models/sport.model';
import { SportService } from '../services/sport.service';
// import { concat } from 'rxjs/operators';

@Component({
  selector: 'app-sport-edit',
  templateUrl: './sport-edit.component.html',
  styleUrls: ['./sport-edit.component.scss']
})
export class SportEditComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute, private sportService: SportService) { }
  model: Sport = {};
  auth: any;
  type: any;
  ngOnInit() {
    this.auth = { isEditor: true };
    this.type = "add";

    this.route.params.pipe(switchMap(params => {
      const id = params['id'];
      if (id !== undefined) {
        this.type = "edit";
        console.log('Sport edit')
        return this.sportService.getSport(id)
      } else {
        console.log('Sport Add')
      }
      return of<Sport>(undefined);
    })
    ).subscribe(sport => {
      if (sport !== undefined) {
        this.model = sport;
      } else {
        //what to do?
      }

    })
  }
  returnPrev(flag: boolean) {

  }
  onSubmit() {
    if (this.type === 'add') {
      this.sportService.addSport(this.model).subscribe(result => {
        if (result === 'OK') {
          console.log("Good! successfuly");
          setTimeout(() => this.router.navigate(['sports']), 2000);
        } else {
          console.log("shit! failed");
        }
      });
    } else {
      this.sportService.editSport(parseInt(this.model.id), this.model).subscribe(result => {
        if (result === 'OK') {
          console.log("Good! successfuly");
          setTimeout(() => this.router.navigate(['sports']), 2000);
        } else {
          console.log("shit! failed");
        }
      });
    }

  }
}
