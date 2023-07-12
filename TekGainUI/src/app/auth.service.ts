
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
private token: string = '';
  private role: string = '';

  constructor(private http: HttpClient) {}

  login(user: User): any {
    return this.http.post<any>('http://localhost:8081/api/Account/signin', user)
      .pipe(
        catchError(this.errorHandler)
      )
      .subscribe((response: any) => {
        const token = response.token;
        this.setToken(token);
        return true;
      }, () => {
        return false;
      });
  }

  setToken(token: string): void {
    this.token = token;
    localStorage.setItem('token', token);
  }

  getToken(): string {

    return this.token;
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
  }

  getRole(): any {
    const token = this.getToken();
    if (token) {
      const decodedToken: any = jwt_decode(token);
      this.role= decodedToken.RoleName;
      return this.role;
    }
    return null;
  }

  private errorHandler(error: HttpErrorResponse): any {
    console.error('An error occurred:', error.error.message);
    localStorage.setItem('token', '');
    return throwError('Something went wrong. Please try again later.');
  }
}

