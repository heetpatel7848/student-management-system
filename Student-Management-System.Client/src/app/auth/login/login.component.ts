import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }

  loginForm !: FormGroup

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  loginUp() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value)
      this.auth.loginUp(this.loginForm.value).subscribe({
        next: (res) => {
          alert(res.message)
          this.loginForm.reset();
          this.router.navigate(['dashboard'])
        },
        error: (err) => {
          alert(err?.error.message)
        }
      })
    }
    else {
      this.validateAllFormFields(this.loginForm);
      alert("form is invalid")
    }
  }

  private validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true })
      } else if (control instanceof FormGroup) {
        this, this.validateAllFormFields(control)
      }
    })
  }

}