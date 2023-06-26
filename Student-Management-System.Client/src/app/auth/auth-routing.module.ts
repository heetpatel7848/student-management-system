import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signupteacher/signup.component';
import { SignupstudentComponent } from './signupstudent/signupstudent.component';
import { TeacherMainComponent } from '../teacher/components/teacher-main/teacher-main.component';
import { TeacherGuard } from '../guards/teacher.guard';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'signupstudent', component: SignupstudentComponent },
  {
    path: 'teacher-main', component: TeacherMainComponent,
    canActivate: [TeacherGuard], // Apply the TeacherGuard to this route
    loadChildren: () => import('../teacher/teacher.module').then((m) => m.TeacherModule),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
