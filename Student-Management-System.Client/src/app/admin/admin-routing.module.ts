import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentManagementComponent } from './StudentManagement/student-management/student-management.component';
import { AdminManagementComponent } from './AdminManagement/admin-management/admin-management.component';
import { TeacherManagementComponent } from './TeacherManagement/teacher-management/teacher-management.component';
import { AdminHeaderComponent } from './admin-header/admin-header.component';
import { TeacherDetailComponent } from './TeacherManagement/teacher-detail/teacher-detail.component';
import { EditTeacherComponent } from './TeacherManagement/edit-teacher/edit-teacher.component';

const routes: Routes = [
  { path: 'admin-header', component: AdminHeaderComponent },
  { path: '', redirectTo: 'student-management', pathMatch: 'full' },
  { path: 'student-management', component: StudentManagementComponent },
  { path: 'admin-management', component: AdminManagementComponent },
  { path: 'teacher-management', component: TeacherManagementComponent },
  { path: 'teacher-detail/:id', component: TeacherDetailComponent },
  { path: 'edit-teacher', component: EditTeacherComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
