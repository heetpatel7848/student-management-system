import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IStudent } from 'src/app/Interface/IStudent';
import { AuthService } from 'src/service/auth.service';
import { StudentService } from 'src/service/student.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss']
})
export class AddStudentComponent {
  constructor(private fb: FormBuilder, private auth: AuthService, private studentService: StudentService, private router: Router) { }


  student !: IStudent;

  addstudentform !: FormGroup;

  ngOnInit(): void {
    this.addstudentform = this.fb.group({
      name: ['', Validators.required],
      class: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      rollNo: ['', Validators.required],
      dateOfAdmission: ['', Validators.required]
    })
  }

  studentrole: any = {
    role: 'student' // Add the 'role' property
  };

  SignupStudent() {
    console.log(this.addstudentform.value)
    const student: IStudent = {
      name: this.addstudentform.value.name,
      email: this.addstudentform.value.email,
      class: this.addstudentform.value.class,
      password: this.addstudentform.value.password,
      dateOfBirth: this.addstudentform.value.dateOfBirth,
      dateOfAdmission: this.addstudentform.value.dateOfAdmission,
      rollNo: this.addstudentform.value.rollNo,
    };

    this.studentService.addStudent(student).subscribe(
      (response) => {
        console.log('Admin added:', response);
        // Perform necessary actions after admin is added
      },
      (error) => {
        console.log('Error adding admin:', error);
      }
    );
  }
}