import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';
import { IAdmin } from 'src/app/Interface/IAdmin';
import { AdminService } from 'src/service/admin.service';

@Component({
  selector: 'app-admin-management',
  templateUrl: './admin-management.component.html',
  styleUrls: ['./admin-management.component.scss']
})
export class AdminManagementComponent {

  public admin: IAdmin[] = [];


  constructor(private adminService: AdminService, private route: Router) { }

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
  }
}






