import { Injectable } from '@angular/core';
import { User } from './user';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: string = '';
  private role: string = '';

  constructor(private http: HttpClient) {}

  login(user: User): any {
    return this.http.post<any>('http://localhost:8081/api/Account/signin', user).pipe(
      catchError((error: HttpErrorResponse) => {
        return throwError(this.errorHandler(error));
      })
    );
  }

  getToken(): any {
    return localStorage.getItem('token');
  }

  getRole(): any {
    const token = this.getToken();
    const decodedToken: any = jwt_decode(token);
    return decodedToken.RoleName;
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
  }

  private errorHandler(error: HttpErrorResponse): string {
    // Handle specific error cases if needed
    return error.message || 'Server error';
  }
}
