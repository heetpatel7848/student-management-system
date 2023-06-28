import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IAdmin } from 'src/app/Interface/IAdmin';
import { AdminService } from 'src/service/admin.service';

@Component({
  selector: 'app-add-admin',
  templateUrl: './add-admin.component.html',
  styleUrls: ['./add-admin.component.scss']
})
export class AddAdminComponent implements OnInit {

  admin !: IAdmin;

  addadminform !: FormGroup



  constructor(private adminService: AdminService, private fb: FormBuilder) { }
  ngOnInit(): void {
    this.addadminform = this.fb.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      createdOn: ['', Validators.required],
    });
  }

  onSubmit() {
    // this.adminService.addAdmin(this.admin).subscribe(
    //   (response) => {
    //     console.log('Admin added:', response);
    //     // Perform necessary actions after admin is added
    //   },
    //   (error) => {
    //     console.log('Error adding admin:', error);
    //   }
    // );
    console.log("u are on onsubmit btn")
    console.log(this.addadminform.value)
  }

}
