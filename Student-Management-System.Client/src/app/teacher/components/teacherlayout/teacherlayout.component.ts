import { Component } from '@angular/core';

@Component({
  selector: 'app-teacherlayout',
  templateUrl: './teacherlayout.component.html',
  styleUrls: ['./teacherlayout.component.scss']
})
export class TeacherlayoutComponent {


  logout() {
    window.alert("Are you sure you want to logout ")
  }

}
