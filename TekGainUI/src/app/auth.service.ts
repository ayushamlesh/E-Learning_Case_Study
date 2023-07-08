
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
 private token: string='';
 private role: string='';

  login(user: User): any {
   //   Fill the code
   return this.http.post<any>('http://localhost:8081/api/Account/signin', user).pipe(
    catchError((error: HttpErrorResponse) => {
      return throwError(this.errorHandler(error));
    })
  );
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
    const token = this.getToken();
    var decodedToken = this.decodeToken(token);
    var roleName = decodedToken.RoleName;
    return roleName;
//  Fill the code
return localStorage.getItem('role');

   }
   decodeToken(token: string): any {
    try {
      const decodedToken = jwt_decode(token);
      return decodedToken;
    } catch (error) {
      console.error('Error decoding token:', error);
      return null;
    }
  }


  constructor(private http: HttpClient) {

  }

  private errorHandler(error: HttpErrorResponse): string {
    // Handle specific error cases if needed
    return error.message || 'Server error';
}
}
