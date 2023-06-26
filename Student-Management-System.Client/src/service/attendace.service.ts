import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAttendance } from 'src/app/Interface/IAttendance';

@Injectable({
  providedIn: 'root'
})
export class AttendaceService {

  private postAttendance = 'http://your-backend-url'; // Replace with your actual backend URL

  constructor(private http: HttpClient) { }

  recordAttendance(attendance: IAttendance): Observable<any> {
    const url = `${this.postAttendance}/record-attendance`;
    return this.http.post(url, attendance);
  }
}
