import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeacherHeaderComponent } from './components/teacher-header/teacher-header.component';
import { RecordAttendanceComponent } from './components/attendance/record-attendance/record-attendance.component';
import { AttendanceHistoryComponent } from './components/attendance/attendance-history/attendance-history.component';
import { AttendanceMainComponent } from './components/attendance/attendance-main/attendance-main.component';

const routes: Routes = [

  { path: 'teacher-header', component: TeacherHeaderComponent },
  {
    path: 'attendance-main', component: AttendanceMainComponent, children: [
      { path: 'record', component: RecordAttendanceComponent },
      { path: 'history', component: AttendanceHistoryComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TeacherRoutingModule { }
