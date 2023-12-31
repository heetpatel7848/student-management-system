import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEditTeacher, ITeacher } from 'src/app/Interface/ITeacher';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  private baseUrl = 'https://localhost:7015'; // Replace with your backend API URL

  constructor(private http: HttpClient) { }

  getTeachers(): Observable<ITeacher[]> {
    return this.http.get<ITeacher[]>(`${this.baseUrl}/api/Teacher`);
  }

  getTeacherById(teacherId: number): Observable<ITeacher> {
    return this.http.get<ITeacher>(`${this.baseUrl}/api/Teacher/id?id=${teacherId}`);
  }

  addTeacher(teacher: ITeacher): Observable<ITeacher> {
    return this.http.post<ITeacher>(`${this.baseUrl}/api/Teacher`, teacher);
  }

  updateTeacher(teacher: IEditTeacher): Observable<ITeacher> {
    return this.http.put<ITeacher>(`${this.baseUrl}/api/Teacher`, teacher);
  }

}
