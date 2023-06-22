
import { RouterTestingModule, } from '@angular/router/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { async, ComponentFixture, TestBed,inject,tick,fakeAsync,flush, getTestBed } from '@angular/core/testing';
import {Router,ActivatedRoute} from "@angular/router";
import { CourseComponent } from './course/course.component';
import { AdmissionComponent } from './admission/admission.component';
import { AssociateComponent } from './associate/associate.component';
import { AuthService } from './auth.service';
import { HttpClient,HttpClientModule, HttpHandler ,HttpResponse } from '@angular/common/http';
import { Component, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { AppModule,routes } from './app.module';
import {Location} from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule,ReactiveFormsModule }   from '@angular/forms';
describe('AppComponent', () => {

  let fixture1:any,fixture2:any,fixture3:any,fixture4:any;
  let app1:any,app2:any,app3:any,app4:any;
  let location: Location;
	let router: Router;
	let fixture;
  let httpClient: HttpClient;
  let httpMock: HttpTestingController;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
		imports: [FormsModule,HttpClientTestingModule,ReactiveFormsModule,RouterTestingModule.withRoutes(routes)],
      declarations: [
        AppComponent,
        CourseComponent,
        AdmissionComponent,
        AssociateComponent
       
      ],

    }).compileComponents();
  }));

  beforeEach(() => {	 	  	  		    	   	 	   	 	
    fixture = TestBed.createComponent(AppComponent);
        app1 = fixture.debugElement.componentInstance;
        fixture2 = TestBed.createComponent(CourseComponent);
        app2 = fixture2.debugElement.componentInstance;   
        httpClient = TestBed.inject(HttpClient);
        httpMock = TestBed.inject(HttpTestingController);
      fixture3 = TestBed.createComponent(CourseComponent);
      app3 = fixture3.componentInstance;
  });  

 
  it('Test for course menu routing' , fakeAsync(() => { 

fail("test case failed");

	}));

  it('Test for Associate menu routing' , fakeAsync(() => { 
	
  fail("test case failed");
  
  
	})); 
  it('Test for Admission menu routing' , fakeAsync(() => { 
	
    
    fail("test case failed");
    
	})); 

});
	 	  	  		    	   	 	   	 	
