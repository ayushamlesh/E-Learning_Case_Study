import { Component, EventEmitter } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  //added variable
  isLoggedIn: boolean = false;

  constructor(private authService: AuthService, private router: Router) {

  }

  ngOnInit(): void {

   //   Fill the code
   const token = this.authService.getToken();
    if (token) {
      this.isLoggedIn = true;
    }

  }
  onlogout() {

   //   Fill the code
   this.authService.logout();
   this.isLoggedIn = false;
   this.router.navigate(['']);

  }



}



