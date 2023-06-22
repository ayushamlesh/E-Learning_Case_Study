import { Injectable } from '@angular/core';

import { HttpClient, HttpErrorResponse, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { observable, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';
@Injectable({
  providedIn: 'root'
})
export class AdmissionService {
    
returnMsg:any='';

  constructor(private http: HttpClient, private authService: AuthService) { }

  registration(associateId: number, courseId: number): Observable<Object> {

   
   //   Fill the code
    return this.returnMsg;
    }

  calculateFees(associateId: number) {
   
   //   Fill the code
    return this.returnMsg;
  }	 	  	  		    	   	 	   	 	

  addFeedback(regNo: number, feedback: string, feedbackRating: number) {

  
   //   Fill the code
    return this.returnMsg;
    }

  highestFeeForTheRegisteredCourse(associateId: number) {

    
   //   Fill the code
    return this.returnMsg;
      
  }

  viewAllAdmissions(): Observable<any> {	 	  	  		    	   	 	   	 	

   
   //   Fill the code
    return this.returnMsg;
  }

  errorHandler(error: HttpErrorResponse) {
     
   //   Fill the code
   
  }
}
