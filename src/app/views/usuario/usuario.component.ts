import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProdutoService } from 'src/app/components/produto/produto.service';
import { Usuario } from './usuario';
import { HeaderComponent } from 'src/app/components/template/header/header.component';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {
  constructor(private produtoService: ProdutoService, private router: Router, private header: HeaderComponent) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == undefined || localStorage.getItem("token") == null) {
      this.produtoService.showMessage('Sem premissão de acesso!');
      this.router.navigate(['/']);
    }
    console.log(this.header.title)
    this.header.title = "Usuario";
  }

  NewUsuario(): void {
    this.router.navigate(['/usuario/create']);
  }
}
