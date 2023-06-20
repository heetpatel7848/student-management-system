import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/service/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent {
  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }

  signupform !: FormGroup;

  ngOnInit(): void {
    this.signupform = this.fb.group({
      name: ['', Validators.required],
      class: ['', Validators.required],
      email: ['', Validators.required],
      subject: ['', Validators.required],
      password: ['', Validators.required],
      dob: ['', Validators.required],
      ed: ['', Validators.required],
      qualification: ['', Validators.required],
    })
  }

  Signup() {
    if (this.signupform.valid) {
      console.log(this.signupform.value)
      this.auth.Signup(this.signupform.value).subscribe({
        next: (res) => {
          alert(res.message)
          this.signupform.reset();
          this.router.navigate(['login']);
        },
        error: (err) => {
          alert(err?.error.message)
        }
      })
    }
    else {
      this.validateAllFormFields(this.signupform);
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
