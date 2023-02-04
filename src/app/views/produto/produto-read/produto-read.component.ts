import { Observable } from 'rxjs';
import { Produto } from './../produto';
import { Component, OnInit } from '@angular/core';
import { ProdutoService } from 'src/app/components/produto/produto.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-produto-read',
  templateUrl: './produto-read.component.html',
  styleUrls: ['./produto-read.component.css']
})
export class ProdutoReadComponent implements OnInit {

  products: Produto[]
  displayedColumns = ['id_produto', 'nm_produto', 'preco', 'action']

  constructor(private produtoService: ProdutoService, private router: Router, private sanckbar: MatSnackBar) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == undefined) {
      this.produtoService.showMessage('Sem premissão de acesso!');
      this.router.navigate(['/']);
    }

    this.produtoService.get().subscribe((f) => {
      this.products = f.data;
      console.log(f.data);
    })
  }

  Excluir(id: string): void {
    var alert = window.confirm('Deseja realiza a exclusão?');
    if (alert) {
      this.produtoService.MostraLoader(true)
      this.produtoService.delete(id).subscribe((f) => { 
        this.produtoService.MostraLoader(false)       
        this.produtoService.showMessage(f.mensagem);
        this.router.navigate(['/produto']);
      })
    }
  }


}
