import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from 'src/service/auth.service';

@Component({
  selector: 'app-add-teacher',
  templateUrl: './add-teacher.component.html',
  styleUrls: ['./add-teacher.component.scss']
})
export class AddTeacherComponent implements OnInit {

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router, private http: HttpClient) { }

  addteacherform !: FormGroup;

  ngOnInit(): void {
    this.addteacherform = this.fb.group({
      name: ['', Validators.required],
      class: ['', Validators.required],
      email: ['', Validators.required],
      subject: ['', Validators.required],
      password: ['', Validators.required],
      dob: ['', Validators.required],
      enrollmentDate: ['', Validators.required],
      qualification: ['', Validators.required],
      salary: ['', Validators.required],
    })
  }

  teacherrole: any = {
    role: 'teacher' // Add the 'role' property
  };


  onSubmit() {
    console.log("u are on submit button")
    const url = 'https://localhost:7015/api/Teacher';
    const formData = this.addteacherform.value;
    console.log(formData);


    this.http.post(url, formData).subscribe(
      (response) => {
        console.log('API response:', response);
      },
      (error) => {
        console.error('API error:', error);
      }
    );
  }

}
