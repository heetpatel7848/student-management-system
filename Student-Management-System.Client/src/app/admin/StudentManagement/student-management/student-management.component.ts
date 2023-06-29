import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { StudentService } from 'src/service/student.service';
import { AddStudentComponent } from '../add-student/add-student.component';
import { EditStudentComponent } from '../edit-student/edit-student.component';

@Component({
  selector: 'app-student-management',
  templateUrl: './student-management.component.html',
  styleUrls: ['./student-management.component.scss']
})
export class StudentManagementComponent {
  student: any = {
    name: '',
    email: '',
    class: '',
    rollNo: ''

  };

  constructor(private studentService: StudentService, private route: Router, private dialog: MatDialog, private dialogRef: MatDialogRef<EditStudentComponent>) { }

  ngOnInit(): void {
    this.fetchStudent();
  }

  fetchStudent() {
    this.studentService.getStudent().subscribe({
      next: (res: any) => {
        this.student = res.data;
        console.log('the  student list ', res);
      },

      error: (error) => {
        console.log(error);
      },
    });
  }



  addStudent() {
    console.log("on add student button ");
    const dialogRef = this.dialog.open(AddStudentComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Teacher added:', result);
      }
    });
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.height = '400px';
    dialogConfig.position = {
      top: '500px'
    };

    this.dialog.open(AddStudentComponent, dialogConfig);
  }

  editStudent(id: number) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.height = '400px';
    dialogConfig.position = {
      top: '50px'
    };
    dialogConfig.data = {
      id: id
    };

    const dialogRef = this.dialog.open(EditStudentComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      // Handle dialog close event
      if (result) {
        console.log('Teacher updated:', result);
        this.studentService.updateStudent(result);
        this.dialogRef.close();
      }
    });
  }
}
