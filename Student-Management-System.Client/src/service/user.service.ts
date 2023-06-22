import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  Signup() {
    this.http.post('https://localhost:7015/api/Teacher', Object).subscribe(res => {
      console.log(res)
    })
  }

  SignupStudent() {
    this.http.post('https://localhost:7015/api/Student', Object).subscribe(res => {
      console.log(res);
    })
  }


}
