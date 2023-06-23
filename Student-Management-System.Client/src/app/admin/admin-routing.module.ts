import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentManagementComponent } from './student-management/student-management.component';
import { AdminManagementComponent } from './admin-management/admin-management.component';
import { TeacherManagementComponent } from './teacher-management/teacher-management.component';
import { AdminComponentComponent } from './admin-component/admin-component.component';
import { AdminHeaderComponent } from './admin-header/admin-header.component';

const routes: Routes = [
  { path: 'admin-header', component: AdminHeaderComponent },
  { path: '', redirectTo: 'student-management', pathMatch: 'full' },
  { path: 'student-management', component: StudentManagementComponent },
  { path: 'admin-management', component: AdminManagementComponent },
  { path: 'teacher-management', component: TeacherManagementComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
