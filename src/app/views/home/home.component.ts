import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from 'src/app/components/template/header/header.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private header: HeaderComponent) {}

  ngOnInit(): void {
    this.header.title = "Home";
  }
}
