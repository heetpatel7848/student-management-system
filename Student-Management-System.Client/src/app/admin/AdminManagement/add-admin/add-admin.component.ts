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
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.addadminform.invalid) {
      return;
    }

    const admin: IAdmin = {
      name: this.addadminform.value.name,
      email: this.addadminform.value.email,
      createdOn: this.addadminform.value.createdOn,
      password: this.addadminform.value.password
    };

    this.adminService.addAdmin(admin).subscribe(
      (response) => {
        console.log('Admin added:', response);
        // Perform necessary actions after admin is added
      },
      (error) => {
        console.log('Error adding admin:', error);
      }
    );
  }


}
