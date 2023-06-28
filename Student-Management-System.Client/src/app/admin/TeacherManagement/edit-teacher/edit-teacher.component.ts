import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { IEditTeacher, ITeacher } from 'src/app/Interface/ITeacher';
import { TeacherService } from 'src/service/teacher.service';

@Component({
  selector: 'app-edit-teacher',
  templateUrl: './edit-teacher.component.html',
  styleUrls: ['./edit-teacher.component.scss']
})
export class EditTeacherComponent implements OnInit {
  id!: number;
  teacher: ITeacher; // Define the Teacher interface or class based on your requirements

  constructor(
    private dialogRef: MatDialogRef<EditTeacherComponent>, private route: ActivatedRoute
    , @Inject(MAT_DIALOG_DATA) private data: ITeacher, private teacherService: TeacherService
  ) {
    this.teacher = { ...data }; // Make a copy of the data object to avoid modifying the original object
  }
  ngOnInit(): void {
    console.log(this.teacher);
  }



  saveTeacher() {
    console.log(this.teacher); // Assuming `id` is the property representing the teacher's ID
    if (this.teacher) {
      const teacher: IEditTeacher = {
        id: this.teacher.id,
        name: this.teacher.name,
        email: this.teacher.email
      }
      this.teacherService.updateTeacher(teacher).subscribe(
        (teacher: any) => {
          this.teacher = teacher.data;
          console.log('update teacher', teacher);

          this.dialogRef.close();
        },
        error => {
          console.error(error);
        }
      );
    }
  }



}