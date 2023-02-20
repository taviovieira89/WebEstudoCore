import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  ehVisivel = true;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == undefined || localStorage.getItem("token") == null) {
      this.ehVisivel = false;
    } else {
      this.ehVisivel = true;
    }
  }
}
