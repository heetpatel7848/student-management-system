import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { TeacherManagementComponent } from './TeacherManagement/teacher-management/teacher-management.component';
import { AdminManagementComponent } from './AdminManagement/admin-management/admin-management.component';
import { AdminHeaderComponent } from './admin-header/admin-header.component';
import { AdminComponentComponent } from './admin-component/admin-component.component';
import { TeacherDetailComponent } from './TeacherManagement/teacher-detail/teacher-detail.component';
import { AddTeacherComponent } from './TeacherManagement/add-teacher/add-teacher.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditTeacherComponent } from './TeacherManagement/edit-teacher/edit-teacher.component';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { AddAdminComponent } from './AdminManagement/add-admin/add-admin.component';
import { EditAdminComponent } from './AdminManagement/edit-admin/edit-admin.component';
import { StudentManagementComponent } from './StudentManagement/student-management/student-management.component';
import { AddStudentComponent } from './StudentManagement/add-student/add-student.component';
import { EditStudentComponent } from './StudentManagement/edit-student/edit-student.component';

@NgModule({
  declarations: [
    TeacherManagementComponent,
    AdminManagementComponent,
    AdminHeaderComponent,
    AdminComponentComponent,
    TeacherDetailComponent,
    AddTeacherComponent,
    EditTeacherComponent,
    AddAdminComponent,
    EditAdminComponent,
    StudentManagementComponent,
    AddStudentComponent,
    EditStudentComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule

  ],
  providers: [
    {
      provide: MatDialogRef,
      useValue: {}
    },
  ]
})
export class AdminModule { }
