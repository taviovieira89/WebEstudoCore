import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProdutoService } from 'src/app/components/produto/produto.service';
import { Produto } from './produto';
import {HeaderComponent} from 'src/app/components/template/header/header.component';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {
  
  constructor(private produtoService: ProdutoService, private router: Router,private header: HeaderComponent) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == undefined) {
      this.produtoService.showMessage('Sem premissão de acesso!');
      this.router.navigate(['/']);
    }
    console.log(this.header.title)
    this.header.title = "Produto";
  }

  NewProduto(): void {
    this.router.navigate(['/produto/create']);
  }

}
