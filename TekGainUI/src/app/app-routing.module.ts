import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AppComponent } from './app.component';
import { CourseComponent } from './course/course.component';
import { AdmissionComponent } from './admission/admission.component';
import { AssociateComponent } from './associate/associate.component';


const routes: Routes = [
  {
    path:'',component:LoginComponent
  },

  {
    path:'a',component:AppComponent
  },
  {
    path:'course',component:CourseComponent
  },
  {
    path:'admission',component:AdmissionComponent
  },
  {
    path:'associate',component:AssociateComponent
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
