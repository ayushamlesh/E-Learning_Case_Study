import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { observable, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';
import { Course } from './course';

@Injectable({
  providedIn: 'root'
})

export class CourseService {

returnMsg:any='';

  ngOnInit() {

  }

  constructor(private http: HttpClient, private authService: AuthService) {

  }
  addCourse(course: Object): Observable<Object> {


   //   Fill the code
    return this.returnMsg;
     }

  updateCourse(courseId: string, fees: number): Observable<Object> {

   //   Fill the code
    return this.returnMsg;
     }

  viewAllCourses(): Observable<any> {

   //   Fill the code
   this.returnMsg=this.http.get<Course[]>('http://localhost:8082/api/Course/GetAllCourse');
    return this.returnMsg;
  }

  viewCourseById(courseId: string): Observable<any> {


   //   Fill the code
    return this.returnMsg;
  }


  errorHandler(error: HttpErrorResponse) {

   //   Fill the code

  }

}
