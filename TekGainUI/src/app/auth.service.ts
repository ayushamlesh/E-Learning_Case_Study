
import { Injectable, EventEmitter } from '@angular/core';
import { User } from './user';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { observable, Observable, of, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import jwt_decode from "jwt-decode";
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private token:string= '';
  private role: string = '';

  login(user: User): any {

    return this.http.post<any>('http://localhost:8081/api/Account/signin', user);
   //   Fill the code

  }


  getToken(): any {

   //   Fill the code
 return localStorage.getItem('token');
  }

  logout(): void {

   //   Fill the code
   localStorage.removeItem('token');
    localStorage.removeItem('role');


  }
  getRole(): any {


   //   Fill the code
   const token = this.getToken();
   const decodedToken: any = jwt_decode(token);
   return decodedToken.RoleName;

   }


  constructor(private http: HttpClient) {

  }

}
