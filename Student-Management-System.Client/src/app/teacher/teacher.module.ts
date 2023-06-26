import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeacherRoutingModule } from './teacher-routing.module';
import { TeacherGuard } from '../guards/teacher.guard';
import { AttendanceHistoryComponent } from './components/attendance/attendance-history/attendance-history.component';
import { AttendanceMainComponent } from './components/attendance/attendance-main/attendance-main.component';
import { TeacherHeaderComponent } from './components/teacher-header/teacher-header.component';
import { TeacherMainComponent } from './components/teacher-main/teacher-main.component';
import { TeacherlayoutComponent } from './components/teacherlayout/teacherlayout.component';
import { RecordAttendanceComponent } from './components/attendance/record-attendance/record-attendance.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AttendanceHistoryComponent,
    AttendanceMainComponent,
    TeacherHeaderComponent,
    TeacherMainComponent,
    TeacherlayoutComponent,
    RecordAttendanceComponent
  ],
  imports: [
    CommonModule,
    TeacherRoutingModule,
    FormsModule
  ],
  providers: [TeacherGuard]
})
export class TeacherModule { }
