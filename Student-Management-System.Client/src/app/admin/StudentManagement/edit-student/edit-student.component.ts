import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { IEditStudent, IStudent } from 'src/app/Interface/IStudent';
import { StudentService } from 'src/service/student.service';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.scss']
})
export class EditStudentComponent {
  id!: number;
  student: IStudent; // Define the Teacher interface or class based on your requirements

  constructor(
    private dialogRef: MatDialogRef<EditStudentComponent>, private route: ActivatedRoute
    , @Inject(MAT_DIALOG_DATA) private data: IStudent, private studentService: StudentService
  ) {
    this.student = { ...data }; // Make a copy of the data object to avoid modifying the original object
  }
  ngOnInit(): void {
    console.log(this.student);
  }

  saveStudent() {
    console.log(this.student);

    if (this.student) {
      const student: IEditStudent = {
        id: this.student.id,
        name: this.student.name,
        email: this.student.email,
        class: this.student.class,
        rollNo: this.student.rollNo
      };

      this.studentService.updateStudent(student).subscribe(
        (updatedStudent: any) => {
          // Update the teacher data
          this.student = updatedStudent.data;

          console.log('Updated teacher:', updatedStudent);
          this.dialogRef.close();
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

}
