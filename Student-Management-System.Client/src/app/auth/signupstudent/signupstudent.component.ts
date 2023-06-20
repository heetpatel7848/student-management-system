import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/service/auth.service';

@Component({
  selector: 'app-signupstudent',
  templateUrl: './signupstudent.component.html',
  styleUrls: ['./signupstudent.component.scss']
})
export class SignupstudentComponent {
  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }

  signupformstudent !: FormGroup;

  ngOnInit(): void {
    this.signupformstudent = this.fb.group({
      name: ['', Validators.required],
      class: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      dob: ['', Validators.required],
      rollno: ['', Validators.required],
      doa: ['', Validators.required]
    })
  }

  Signup() {
    if (this.signupformstudent.valid) {
      console.log(this.signupformstudent.value)
      this.auth.Signup(this.signupformstudent.value).subscribe({
        next: (res) => {
          alert(res.message)
          this.signupformstudent.reset();
          this.router.navigate(['login']);
        },
        error: (err) => {
          alert(err?.error.message)
        }
      })
    }
    else {
      this.validateAllFormFields(this.signupformstudent);
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
