import { Component } from '@angular/core';
import { SportService } from '../../sports/services/sport.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent {
  constructor(private sportservice: SportService, private router: Router) { }
  public userName: string;
  public password: string;
  onSubmit(){
    this.sportservice.login(this.userName, this.password).subscribe(() => {
      // this.authenticating = false;
      this.redirect();
    }, (error) => {
      // this.authenticating = false;
      // this.error = true;
    }
    );
  }
  redirect(){
    this.router.navigateByUrl('');
  }
 }
