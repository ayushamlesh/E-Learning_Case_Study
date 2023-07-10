
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

  setToken(token: string): void {
    this.token = token;
    localStorage.setItem('token', token);
  }

  getToken(): string {

   //   Fill the code

  return this.token;
  }

  logout(): void {

   //   Fill the code
   localStorage.removeItem('token');
   localStorage.removeItem('role');


  }
  getRole(): any {


   //   Fill the code
   const token = this.getToken();
   if (token) {
     const decodedToken: any = jwt_decode(token);
     this.role= decodedToken.RoleName;
     return this.role;
   }
   return null;

   }


  constructor(private http: HttpClient) {

  }

}
