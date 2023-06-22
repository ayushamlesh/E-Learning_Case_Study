
import { Associate } from './associate';
import { Component, OnInit, Input, } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { observable, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';
@Injectable({
  providedIn: 'root'
})
export class AssociateService {
    
returnMsg:any='';

  constructor(private http: HttpClient, private authService: AuthService) { }

  addAssociate(associate: Object): Observable<Object> {

    
   //   Fill the code
    return this.returnMsg;
     }

  updateAssociate(AssociateId: number, address: string): Observable<Object> {
    
   //   Fill the code
    return this.returnMsg;
  }

  viewAssociates(): Observable<any> {

    
   //   Fill the code
    return this.returnMsg;
  }
  viewAssociateById(associateId: number): Observable<any> {

   
   //   Fill the code
    return this.returnMsg;
  }	 	  	  		    	   	 	   	 	
  errorHandler(error: HttpErrorResponse) {
    
   //   Fill the code
   
  }
}
