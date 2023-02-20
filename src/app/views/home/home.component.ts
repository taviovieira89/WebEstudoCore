import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from 'src/app/components/template/header/header.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private header: HeaderComponent) {
    if (localStorage.getItem("Logout") != undefined &&
      localStorage.getItem("Logout") != null) {
      window.location.reload();
      localStorage.removeItem("Logout")
    }
  }

  ngOnInit(): void {
    this.header.title = "Home";
  }
}
