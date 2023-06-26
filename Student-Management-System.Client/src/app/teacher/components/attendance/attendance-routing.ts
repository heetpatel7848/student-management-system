import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecordAttendanceComponent } from './record-attendance/record-attendance.component';
import { AttendanceHistoryComponent } from './attendance-history/attendance-history.component';

const routes: Routes = [
    { path: 'record', component: RecordAttendanceComponent },
    { path: 'history', component: AttendanceHistoryComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AttendanceRouting { }
