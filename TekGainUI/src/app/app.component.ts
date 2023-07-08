import { Component, EventEmitter } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {


  constructor(private authService: AuthService, private router: Router) {

  }

  ngOnInit(): void {

   //   Fill the code
   void {
    // Check if the user is already logged in
    if (this.authService.isLoggedIn()) {
      this.isLoggedIn = true;
    }

  }
  onlogout() {

   //   Fill the code
   this.authService.logout();

  }



}



