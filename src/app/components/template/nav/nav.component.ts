import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  ehVisivel = true;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    debugger
    if (localStorage.getItem("token") == undefined || localStorage.getItem("token") == null) {
      this.ehVisivel = false;
    } else {
      this.ehVisivel = true;
    }
  }
}
