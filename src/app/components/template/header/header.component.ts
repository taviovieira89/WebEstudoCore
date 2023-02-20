import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  ehVisivel = true;
  title: string = ""

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == undefined || localStorage.getItem("token") == null) {
      this.ehVisivel = false;
    } else {
      this.ehVisivel = true;
    }
    console.log(this.title)
    this.title = "Sistema de Estoque"
  }

  logout(): void {
    localStorage.removeItem("token")
    localStorage.removeItem("UserId")
    this.router.navigate(['/']);
  }
}
