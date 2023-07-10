
import { Component, OnInit,Input } from '@angular/core';
import { User } from '../user';
import { FormGroup, FormControl } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
@Component({
   selector: 'app-login',
   templateUrl: './login.component.html',
   styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Input() user:any=new User('','');
  message:string="";
  isFormSubmitted = false;

  constructor(private authService : AuthService, private router : Router) { }

  ngOnInit(): void {
    this.authService.logout();
  }

  onClickSubmit(): void {
    this.isFormSubmitted = true;
    this.authService.login(this.user)
      .subscribe(
        (response: any) => {
          this.authService.getToken();
          console.log("Logged in successfully");
          this.router.navigate(['course']);
        },
        (error: any) => {
          this.message = "Invalid email/password";
          alert("Invalid email/password");
        }
      );
  }
}
