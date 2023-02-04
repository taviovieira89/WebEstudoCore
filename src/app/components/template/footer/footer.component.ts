import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {
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
