import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ITeacher } from 'src/app/Interface/ITeacher';
import { TeacherService } from 'src/service/teacher.service';

@Component({
  selector: 'app-teacher-detail',
  templateUrl: './teacher-detail.component.html',
  styleUrls: ['./teacher-detail.component.scss']
})
export class TeacherDetailComponent {
  teacher!: ITeacher;

  constructor(
    private route: ActivatedRoute,
    private teacherService: TeacherService
  ) { }

  ngOnInit() {
    this.getTeacherDetails();
  }

  getTeacherDetails() {
    const teacherId = this.route.snapshot.paramMap.get('id');
    console.log(teacherId);
    if (teacherId) {
      this.teacherService.getTeacherById(+teacherId).subscribe(
        (teacher: any) => {
          this.teacher = teacher.data;
          console.log('byidddddd ----- ', teacher);
        },
        error => {
          console.error(error);
        }
      );
    }
  }
}
