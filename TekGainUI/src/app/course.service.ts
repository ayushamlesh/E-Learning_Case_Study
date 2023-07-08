import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { observable, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})

export class CourseService {
   url = 'http://localhost:8082/api/Course/';
returnMsg:any='';
  ngOnInit() {

  }

  constructor(private http: HttpClient, private authService: AuthService) {

  }


  addCourse(course: Object): Observable<Object> {


   //   Fill the code
  // this.returnMsg= this.http.post(this.url+"AddCourse", course).pipe(catchError(this.errorHandler));

   return this.returnMsg;
     }

  updateCourse(courseId: string, fees: number): Observable<Object> {

   //   Fill the code

    // const updatedCourse = { fees };

    // this.returnMsg= this.http.put(this.url+`UpdateCourse/${courseId}`, updatedCourse).pipe(catchError(this.errorHandler));
    return this.returnMsg;
     }

  viewAllCourses(): Observable<any> {

   //   Fill the code

    // this.returnMsg= this.http.get(this.url+"GetAllCourse").pipe(catchError(this.errorHandler));
    return this.returnMsg;
  }

  viewCourseById(courseId: string): Observable<any> {


   //   Fill the code
    // this.returnMsg = this.http.get(this.url+`GetCourseById/${courseId}`).pipe(catchError(this.errorHandler));
    return this.returnMsg;
  }

  viewRatingById(id:number): Observable<any>{
    // this.returnMsg=this.http.get(this.url+`GetRating/${id}`).pipe(catchError(this.errorHandler));
    return this.returnMsg;
  }

  calculateAverageRating(id:number,rating:number):Observable<any>{
    // this.returnMsg=this.http.get(this.url+`CalculateAverageRating/${id}/${rating}`).pipe(catchError(this.errorHandler));
    return this.returnMsg;
  }




  errorHandler(error: HttpErrorResponse) {

   //   Fill the code
   return throwError(error.message || 'Server error');
  }

}
