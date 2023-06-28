import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Route, Router } from '@angular/router';
import { IAdmin } from 'src/app/Interface/IAdmin';
import { AdminService } from 'src/service/admin.service';
import { AddAdminComponent } from '../add-admin/add-admin.component';

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

  constructor(private adminService: AdminService, private route: Router, private dialog: MatDialog) { }

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

  editAdmin(admin: IAdmin) {
    console.log("edit admin");
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






