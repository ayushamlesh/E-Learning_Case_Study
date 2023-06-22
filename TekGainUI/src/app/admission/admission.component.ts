import { Component, OnInit, Input, } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../course.service';
import { AssociateService } from '../associate.service';
import { AdmissionService } from '../admission.service';
import { Admission } from '../admission';

@Component({
  selector: 'app-admission',
  templateUrl: './admission.component.html',
  styleUrls: ['./admission.component.css']
})
export class AdmissionComponent implements OnInit {
 
  role: string = '';
  id: any;
  courseId: any;
  associateId: any;
  courseName: string = '';
  associateName: string = '';
  feedback: string = '';
  returnfees: any = '';
  message1: string = '';
  message2: string = '';
  message3: string = '';
  error: string = '';
  Status: string = '';
  rating: number = 0;

  @Input() admission: any = new Admission(0, 0, 0, '', '', 0);
  admissionModel: any = new Admission(0, 0, 0, '', '', 0);

  assocaiteId: number = 0;
  allAssociate: Array<any> = [];
  admissions: Array<any> = [];
  courses: Array<any> = [];
  coursesbyregistration: Array<any> = [];
  associates: Array<any> = [];
  registeredAssociates: Array<any> = []
  emailId: string = '';
  feedbackArray: Array<Admission> = [];

  AdmissionsArray = [];
  lowestFees: number = 0;
  flag1 = 0;
  flag2 = 0;
  paramFlag = 1;
  sub: any = "";
  returnedCourseId: any = '';
  userEmail: string = '';
  @Input() title: string = '';
  highestFeeArray: Array<any> = [];
  highestMaxFeeArray: Array<any> = [];
  maxFee: any = {};

  ngOnInit() {	 	  	  		    	   	 	   	 	
    
   //   Fill the code
   
  }	 	  	  		    	   	 	   	 	

  ngOnDestroy() {
     
   //   Fill the code
   
  }

  constructor(private admissionService: AdmissionService, private courseService: CourseService, private associateService: AssociateService, private router: Router, private _Activatedroute: ActivatedRoute) { }

 
  registration(): void {
   
   //   Fill the code
   

  }

  totalFees() {
    
   //   Fill the code
   
  }

  addFeedback(): void {
    
   //   Fill the code
   
  }

  highestFee(): void {
   
   //   Fill the code
   
  }	 	  	  		    	   	 	   	 	

  viewFeedbackByCourseId() {
    
   //   Fill the code
   
  }

 

}

	 	  	  		    	   	 	   	 	
