import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ITeacher } from 'src/app/Interface/ITeacher';
import { TeacherService } from 'src/service/teacher.service';
import { AddTeacherComponent } from '../add-teacher/add-teacher.component';
import { EditTeacherComponent } from '../edit-teacher/edit-teacher.component';

@Component({
  selector: 'app-teacher-management',
  templateUrl: './teacher-management.component.html',
  styleUrls: ['./teacher-management.component.scss']
})
export class TeacherManagementComponent implements OnInit {

  public teachers: ITeacher[] = [];
  public existingTeachers: ITeacher[] = [];

  constructor(private teacherService: TeacherService, private route: Router, public dialog: MatDialog, private dialogRef: MatDialogRef<EditTeacherComponent>) { }

  ngOnInit() {
    this.fetchTeachers();
  }

  fetchTeachers() {
    this.teacherService.getTeachers().subscribe({
      next: (res: any) => {
        this.teachers = res.data;
        console.log('the  teacher list ', res);
      },

      error: (error) => {
        console.log(error);
      },
    });
  }


  addTeacher() {
    console.log("add teacher button");
    const dialogRef = this.dialog.open(AddTeacherComponent);
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

    this.dialog.open(AddTeacherComponent, dialogConfig);
  }


  viewTeacherDetails(id: number | undefined) {
    this.route.navigate([`/teacher-detail/${id}`])
    console.log("you are in teacher detail component");
  }

  editTeacher(id: number) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.height = '400px';
    dialogConfig.position = {
      top: '50px'
    };
    dialogConfig.data = {
      id: id
    };

    const dialogRef = this.dialog.open(EditTeacherComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      // Handle dialog close event
      if (result) {
        console.log('Teacher updated:', result);
        this.teacherService.updateTeacher(result);
        this.dialogRef.close();
      }
    });
  }
}
