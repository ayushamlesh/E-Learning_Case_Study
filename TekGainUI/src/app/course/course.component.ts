import { Component, OnInit, Input, } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../course.service';
import { Course } from '../course';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  role: String = "";
  id: any;
  name: string = '';
  fee: number = 0;
  rating: number = 0;
  duration: number = 0;
  type: string = '';
  ls = localStorage.getItem("accessToken");
  message: string = '';
  instructorNames: string = '';
  error: string = '';
  message1: string = '';
  message2: string = '';
  message3: string = '';
  courseError: Array<any> = [];
  @Input() course: any = new Course(0, '', 0, 0, '', 0);
  courseModel: any = new Course(0, '', 0, 0, '', 0);

  courses: Array<any> = [];
  courseById: Array<Course> = [];
  ratings: Array<Course> = [];

  flag1 = 0;
  flag2 = 0;
  paramFlag = 1;
  sub: any = "";

  @Input() title: string = '';

  ngOnInit() {

   //   Fill the code
   this.sub = this._Activatedroute.queryParams.subscribe(params => {
    this.paramFlag = params['paramFlag'];
  });

  }

  ngOnDestroy() {

   //   Fill the code
   this.sub.unsubscribe();


  }

  constructor(private courseService: CourseService, private router: Router, private _Activatedroute: ActivatedRoute) { }

  addCourse(): void {

   //   Fill the code
  this.course = new Course(
    this.id,
    this.name,
    this.fee,
    this.rating,
    this.type,
    this.duration

  );

  this.courseService.addCourse(this.course).subscribe(
    response => {
      // Handle the success response
      this.message = 'Course added successfully.';
      this.error = '';
    },
    error => {
      // Handle the error response
      this.error = 'Failed to add the course.';
      this.message = '';
    }
  );

  }


  updateCourse(): void {


   //   Fill the code
  //    this.course = new Course(this.id, '', this.fee, 0, 0, '');
   this.courseService.updateCourse(this.id, this.fee).subscribe(
     response => {
       // Handle the success response
       this.message = 'Course updated successfully.';
       this.error = '';
     },
     error => {
       // Handle the error response
       this.error = 'Failed to update the course.';
       this.message = '';
     }
   );


     }



  viewCourseById(): void {

   //   Fill the code
   this.courseService.viewCourseById(this.id).subscribe(
    response => {
      // Handle the success response
      this.courseById = response;
      this.error = '';
    },
    error => {
      // Handle the error response
      this.error = 'Failed to retrieve the course by ID.';
      this.courseById = [];
    }
  );

  }

  viewByRatings() {

   //   Fill the code
   this.courseService.viewRatingById(this.id).subscribe(
    response => {
      // Handle the success response
      this.ratings = response;
      this.error = '';
    },
    error => {
      // Handle the error response
      this.error = 'Failed to retrieve the ratings.';
      this.ratings = [];
    }
  );
}

calculateAverageRatings() {

  //   Fill the code
  this.courseService.calculateAverageRating(this.id,this.rating).subscribe(
   response => {
     // Handle the success response
     this.ratings = response;
     this.error = '';
   },
   error => {
     // Handle the error response
     this.error = 'Failed to retrieve average the ratings.';
     this.ratings = [];
   }
 );
}


  }

