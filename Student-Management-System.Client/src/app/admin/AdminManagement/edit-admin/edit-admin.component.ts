import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { IAdmin, IEditAdmin } from 'src/app/Interface/IAdmin';
import { AdminService } from 'src/service/admin.service';

@Component({
  selector: 'app-edit-admin',
  templateUrl: './edit-admin.component.html',
  styleUrls: ['./edit-admin.component.scss']
})
export class EditAdminComponent {
  id!: number;
  admin: IAdmin; // Define the Teacher interface or class based on your requirements

  constructor(
    private dialogRef: MatDialogRef<EditAdminComponent>, private route: ActivatedRoute
    , @Inject(MAT_DIALOG_DATA) private data: IAdmin, private adminService: AdminService
  ) {
    this.admin = { ...data }; // Make a copy of the data object to avoid modifying the original object
  }
  ngOnInit(): void {
    console.log(this.admin);
  }

  saveadmin() {
    // console.log(this.admin);
    console.log(this.admin.id)

    if (this.admin) {
      const admin: IEditAdmin = {
        id: this.admin.id,
        name: this.admin.name,
        email: this.admin.email,
        createdOn: this.admin.createdOn,
        password: this.admin.password

      };

      this.adminService.updateAdmin(admin).subscribe(
        (updatedAdmin: any) => {
          // Update the teacher data
          this.admin = updatedAdmin.data;


          console.log('Updated teacher:', updatedAdmin);
          this.dialogRef.close();
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }
}