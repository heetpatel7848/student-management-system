import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, catchError, map, throwError } from 'rxjs';
import { IUser } from 'src/app/Interface/IUser';
import { AuthService } from 'src/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(private fb: FormBuilder, private http: HttpClient, private auth: AuthService, private router: Router) { }

  loginForm !: FormGroup


  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      role: ['', Validators.required]
    })
  }

  // loginUp() {
  //   if (this.loginForm.valid) {
  //     console.log(this.loginForm.value)
  //     this.loginForm.reset();
  //     this.router.navigate(['admin-header']);
  //   }

  // Sign-in

  loginUser() {
    this.auth.signIn(this.loginForm.value);
    const role = this.loginForm.value.role;
    localStorage.setItem('role', role);
    // Navigate to the appropriate module based on the role
    if (role === 'teacher') {
      this.router.navigate(['../teacher-layout']); // Navigate to the teacher module route
    } else if (role === 'admin') {
      this.router.navigate(['/admin']); // Navigate to the admin module route
    } else if (role === 'student') {
      this.router.navigate(['/student']); // Navigate to the student module route
    } else {
      // Handle any other role or error scenario
      console.log('Invalid role or error occurred');
    }
  }
}


    // loginUp() {
    //   if (this.loginForm.valid) {
    //     console.log(this.loginForm.value)
    //     this.auth.loginUp(this.loginForm.value).subscribe({
    //       next: (res) => {
    //         alert(res.message)
    //         this.loginForm.reset();
    //         this.router.navigate(['admin-header'])
    //       },
    //       error: (err) => {
    //         alert(err?.error.message)
    //       }
    //     })
    //   }
    //   else {
    //     this.validateAllFormFields(this.loginForm);
    //     alert("form is invalid")
    //   }
    // }

    // private validateAllFormFields(formGroup: FormGroup) {
    //   Object.keys(formGroup.controls).forEach(field => {
    //     const control = formGroup.get(field);
    //     if (control instanceof FormControl) {
    //       control.markAsDirty({ onlySelf: true })
    //     } else if (control instanceof FormGroup) {
    //       this, this.validateAllFormFields(control)
    //     }
    //   })
    // }
