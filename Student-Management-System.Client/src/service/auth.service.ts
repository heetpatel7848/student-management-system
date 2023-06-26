import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { IUser } from 'src/app/Interface/IUser';
import { Observable, catchError, map, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  BaseUrl1: string = "https://localhost:7015"
  BaseUrl2: string = "https://localhost:7015"
  endpoint: string = 'https://localhost:7015/api';
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  currentUser = {};
  constructor(private http: HttpClient, public router: Router) { }
  access_token !: any;


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

  signIn(user: IUser) {
    return this.http
      .post<any>(`${this.endpoint}/Auth/login`, user)
      .subscribe((res: any) => {
        localStorage.setItem('access_token', JSON.stringify(res));
        console.log(res);
        alert('Login successful'); // Display alert message
      });
  }

  getToken() {
    return localStorage.getItem('access_token');
  }
  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('access_token');
    return authToken !== null ? true : false;
  }
  doLogout() {
    let removeToken = localStorage.removeItem('access_token');
    if (removeToken == null) {
      this.router.navigate(['login']);
    }
  }
  // User profile
  getUserProfile(id: any): Observable<any> {
    let api = `${this.endpoint}/user-profile/${id}`;
    return this.http.get(api, { headers: this.headers }).pipe(
      map((res) => {
        return res || {};
      }),
      catchError(this.handleError)
    );
  }

}

