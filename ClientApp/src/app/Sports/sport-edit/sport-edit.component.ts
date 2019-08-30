import { Component, OnInit } from '@angular/core';
import { Observable, concat, of } from 'rxjs';
import { takeUntil, tap, flatMap, switchMap, map } from 'rxjs/operators';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Sport } from '../models/sport.model';
import { SportService } from '../services/sport.service';
// import { concat } from 'rxjs/operators';
import { DatepickerOptions } from 'ng2-datepicker';
import * as zhLocale from 'date-fns/locale/zh_cn';
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
  date: any;
  options: DatepickerOptions;

  ngOnInit() {
    this.options = {
      minYear: 1970,
      maxYear: 2030,
      displayFormat: 'MMM D[,] YYYY',
      barTitleFormat: 'MMMM YYYY',
      dayNamesFormat: 'dd',
      firstCalendarDay: 0, // 0 - Sunday, 1 - Monday
      locale: zhLocale,
      // minDate: new Date(Date.now()), // Minimal selectable date
      // maxDate: new Date(Date.now()),  // Maximal selectable date
      barTitleIfEmpty: 'Click to select a date',
      placeholder: 'Click to select a date', // HTML input placeholder attribute (default: '')
      addClass: 'form-control', // Optional, value to pass on to [ngClass] on the input field
      addStyle: {}, // Optional, value to pass to [ngStyle] on the input field
      fieldId: 'my-date-picker', // ID to assign to the input field. Defaults to datepicker-<counter>
      useEmptyBarTitle: false, // Defaults to true. If set to false then barTitleIfEmpty will be disregarded and a date will always be shown 
    };
    this.auth = { isEditor: true };
    this.type = "add";
    this.date = "08/29/2019";
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
