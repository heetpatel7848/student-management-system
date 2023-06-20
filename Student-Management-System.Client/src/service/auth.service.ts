import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  BaseUrl: string = "https://localhost:7015"

  constructor(private http: HttpClient) { }

  Signup(userObj: any) {
    return this.http.post<any>(`${this.BaseUrl}register`, userObj)
  }

  loginUp(loginObj: any) {
    return this.http.post<any>(`${this.BaseUrl}authenticate`, loginObj)
  }
}
