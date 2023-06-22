import { Component, OnInit, Input, } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { AssociateService } from '../associate.service';
import { Associate } from '../associate';

@Component({
  selector: 'app-associate',
  templateUrl: './associate.component.html',
  styleUrls: ['./associate.component.css']
})
export class AssociateComponent implements OnInit {

  role: string = "";
  id: number = 0;
  name: string = '';
  address: string = '';
  email: string = '';
  phoneNumber: string = '';
  userEmail: string = '';
  message1: string = '';
  message2: string = '';
  error: string = '';
  associateError: Array<any> = [];

  @Input() associate: any = new Associate(0, '', '', '', '');
  associateModel: any = new Associate(0, '', '', '', '');
  userObject: any = new Associate(0, '', '', '', '');

  associates: Array<any> = [];
  associatesById: Array<any> = [];

  flag1 = 0;
  flag2 = 0;
  paramFlag = 1;
  sub: any = "";

  @Input() title: string = '';

  ngOnInit() {	 	  	  		    	   	 	   	 	
     
   //   Fill the code
   
  }


  ngOnDestroy() {
     
   //   Fill the code
   
  }	 	  	  		    	   	 	   	 	

  constructor(private associateService: AssociateService, private router: Router, private _Activatedroute: ActivatedRoute) { }

 
  addAssociate(): void {
     
   //   Fill the code
   
  }


  updateAssociate(): void {
     
   //   Fill the code
   

  }

  viewAssociates(): void {	 	  	  		    	   	 	   	 	
     
   //   Fill the code
   
  }
  	  		    	   	 	   	 	

}

