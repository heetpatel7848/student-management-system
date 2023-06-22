import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { IUser } from 'src/app/Interface/IUser';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  BaseUrl1: string = "https://localhost:7015"
  BaseUrl2: string = "https://localhost:7015"
  constructor(private http: HttpClient, public router: Router) { }

  loginUp(loginObj: any) {
    return this.http.post<any>(`${this.BaseUrl1}authenticate`, loginObj)
  }

  // Sign-up Teacher
  signUp(user: IUser): Observable<any> {
    let api = `${this.BaseUrl2}/api/Teacher`;
    return this.http.post(api, user).pipe(catchError(this.handleError));
  }

  //Sign-Up Student
  SignupStudent(user: IUser): Observable<any> {
    let api = `${this.BaseUrl2}/api/Student`;
    return this.http.post(api, user).pipe(catchError(this.handleError));
  }

  // Error
  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      msg = error.error.message;
    } else {
      // server-side error
      msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(msg);
  }

}
