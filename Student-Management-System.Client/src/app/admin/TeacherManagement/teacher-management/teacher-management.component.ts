import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ITeacher } from 'src/app/Interface/ITeacher';
import { TeacherService } from 'src/service/teacher.service';

@Component({
  selector: 'app-teacher-management',
  templateUrl: './teacher-management.component.html',
  styleUrls: ['./teacher-management.component.scss']
})
export class TeacherManagementComponent implements OnInit {

  public teachers: ITeacher[] = [];

  constructor(private teacherService: TeacherService, private route: Router) { }

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
    console.log("add teacher button")
  }

  viewTeacherDetails(id: number | undefined) {
    this.route.navigate([`/teacher-detail/${id}`])
    console.log("you are in teacher detail component");
  }
}
