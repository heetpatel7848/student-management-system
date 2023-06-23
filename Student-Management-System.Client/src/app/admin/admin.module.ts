import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { StudentManagementComponent } from './student-management/student-management.component';
import { TeacherManagementComponent } from './teacher-management/teacher-management.component';
import { AdminManagementComponent } from './admin-management/admin-management.component';
import { AdminHeaderComponent } from './admin-header/admin-header.component';
import { AdminComponentComponent } from './admin-component/admin-component.component';


@NgModule({
  declarations: [
    StudentManagementComponent,
    TeacherManagementComponent,
    AdminManagementComponent,
    AdminHeaderComponent,
    AdminComponentComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
