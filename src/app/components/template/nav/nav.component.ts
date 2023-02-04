import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {

  ehVisivel: boolean = true;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == undefined || localStorage.getItem("token") == null) {
      this.ehVisivel = true;
    } else {
      this.ehVisivel = false;
    }
  }

}
