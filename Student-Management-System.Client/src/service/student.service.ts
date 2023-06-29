import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEditStudent, IStudent } from 'src/app/Interface/IStudent';

@Injectable({
  providedIn: 'root'
})
export class StudentService {


  private apiUrl = 'https://localhost:7015/api/Student';

  constructor(private http: HttpClient) { }

  getStudent(): Observable<IStudent> {
    return this.http.get<IStudent>(`${this.apiUrl}`);
  }

  addStudent(student: IStudent): Observable<IStudent> {
    return this.http.post<IStudent>(`${this.apiUrl}`, student);
  }

  updateStudent(student: IEditStudent): Observable<IStudent> {
    return this.http.put<IStudent>(`${this.apiUrl}`, student);
  }

}
