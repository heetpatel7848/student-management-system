import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { Route, Router } from '@angular/router';
import { IAdmin } from 'src/app/Interface/IAdmin';
import { AdminService } from 'src/service/admin.service';
import { AddAdminComponent } from '../add-admin/add-admin.component';
import { EditAdminComponent } from '../edit-admin/edit-admin.component';

@Component({
  selector: 'app-admin-management',
  templateUrl: './admin-management.component.html',
  styleUrls: ['./admin-management.component.scss']
})
export class AdminManagementComponent {

  // public admin: IAdmin[] = [];

  admin: any = {
    name: '',
    email: '',
    createdOn: ''
  };

  constructor(private adminService: AdminService, private route: Router, private dialog: MatDialog, private dialogRef: MatDialogRef<EditAdminComponent>) { }

  ngOnInit(): void {
    this.fetchAdmin();
  }

  fetchAdmin() {
    this.adminService.getAdmin().subscribe({
      next: (res: any) => {
        this.admin = res.data;
        console.log('the  admin list ', res);
      },

      error: (error) => {
        console.log(error);
      },
    });
  }

  editAdmin(id: number) {
    console.log("edit admin");

    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.height = '400px';
    dialogConfig.position = {
      top: '50px'
    };
    dialogConfig.data = {
      id: id
    };

    const dialogRef = this.dialog.open(EditAdminComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      // Handle dialog close event
      if (result) {
        console.log('Admin updated:', result);
        this.adminService.updateAdmin(result);
        this.dialogRef.close();
      }
    });
  }

  addAdmin() {
    console.log("add admin");
    const dialogRef = this.dialog.open(AddAdminComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      // Perform necessary actions after admin is added
    });
  }
}






