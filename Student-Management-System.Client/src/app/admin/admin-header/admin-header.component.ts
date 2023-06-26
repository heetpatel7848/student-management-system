import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-header',
  templateUrl: './admin-header.component.html',
  styleUrls: ['./admin-header.component.scss']
})
export class AdminHeaderComponent {

  logout() {
    localStorage.clear();
    window.alert("Are you sure that you want to LOGOUT !")
  }
}
