import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TeacherGuard implements CanActivate {

  constructor(private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree {

    const role = localStorage.getItem('role'); // Get the role from local storage

    if (role === 'teacher') {
      return true; // Allow access for teacher role
    } else {
      // Redirect to a different route if the role is not teacher
      return this.router.parseUrl('/teacher-main');
    }
  }

}
