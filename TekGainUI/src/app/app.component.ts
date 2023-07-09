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
   

  }
  onlogout() {
    
   //   Fill the code
   
  }	 	  	  		    	   	 	   	 	

 
}



