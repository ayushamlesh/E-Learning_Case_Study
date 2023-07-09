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


  }

  constructor(private courseService: CourseService, private router: Router, private _Activatedroute: ActivatedRoute) { }

  addCourse(): void {

   //   Fill the code



  }


  updateCourse(): void {


   //   Fill the code

     }



  viewCourseById(): void {

   //   Fill the code


  }

  viewRatings() {

   //   Fill the code

  }





}
