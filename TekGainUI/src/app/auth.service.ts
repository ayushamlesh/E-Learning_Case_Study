
import { Injectable, EventEmitter } from '@angular/core';
import { User } from './user';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { observable, Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import jwt_decode from "jwt-decode";
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  login(user: User): any {

    
   //   Fill the code
    return false;
  }
  
  
  getToken(): any {
     
   //   Fill the code
   return "";
  }

  logout(): void {
    
   //   Fill the code
   
  }
  getRole(): any {

    
   //   Fill the code
   return "";
   }
  constructor(private http: HttpClient) {
   
  }	 	  	  		    	   	 	   	 	
}
