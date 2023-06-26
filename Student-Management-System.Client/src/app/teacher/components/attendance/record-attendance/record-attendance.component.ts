import { Component } from '@angular/core';
import { IAttendance } from 'src/app/Interface/IAttendance';
import { AttendaceService } from 'src/service/attendace.service';

@Component({
  selector: 'app-record-attendance',
  templateUrl: './record-attendance.component.html',
  styleUrls: ['./record-attendance.component.scss']
})



export class RecordAttendanceComponent {

  attendance: IAttendance = {
    studentName: '',
    subject: '',
    date: new Date(),
    attendance: false
  };


  constructor(private attendanceService: AttendaceService) { }

  submittedAttendance: IAttendance[] = [];

  submitAttendance() {
    this.attendanceService.recordAttendance(this.attendance).subscribe(
      response => {
        // Handle success response
        console.log(response);
        this.submittedAttendance.push(this.attendance); // Add submitted attendance to the array
        this.attendance = { // Reset the form fields
          studentName: '',
          subject: '',
          date: new Date(),
          attendance: false
        };
      },
      error => {
        // Handle error response
        console.error(error);
      }
    );
  }

}
