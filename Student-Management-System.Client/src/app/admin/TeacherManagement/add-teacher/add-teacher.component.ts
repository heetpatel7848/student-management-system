import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-teacher',
  templateUrl: './add-teacher.component.html',
  styleUrls: ['./add-teacher.component.scss']
})
export class AddTeacherComponent implements OnInit {

  teacherForm!: FormGroup;
  teacher: any = {};


  constructor(private formBuilder: FormBuilder, private http: HttpClient, public dialogRef: MatDialogRef<AddTeacherComponent>) { }

  ngOnInit(): void {
    this.teacherForm = this.formBuilder.group({
      name: ['', Validators.required],
      class: ['', Validators.required],
      password: ['', Validators.required],
      subject: ['', Validators.required],
      qualification: ['', Validators.required],
      salary: ['', Validators.required],
      dob: ['', Validators.required],
      enrollmentDate: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  teacherrole: any = {
    role: 'teacher' // Add the 'role' property
  };


  onSubmit() {
    console.log("u are on submit button")
    const url = 'https://localhost:7015/api/Teacher';
    const formData = this.teacherForm.value;

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
