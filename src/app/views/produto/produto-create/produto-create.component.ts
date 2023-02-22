import { Produto } from './../produto';
import { Component, OnInit } from '@angular/core';
import { ProdutoService } from 'src/app/components/produto/produto.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-produto-create',
  templateUrl: './produto-create.component.html',
  styleUrls: ['./produto-create.component.css']
})
export class ProdutoCreateComponent implements OnInit {

  product: Produto = {
    nm_produto: '',
    preco: undefined
  }

  title: string = "Novo Produto";
  edicao: boolean = false;

  constructor(private produtoService: ProdutoService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {

    if (localStorage.getItem("token") == undefined || localStorage.getItem("token") == null) {
      this.produtoService.showMessage('Sem premissão de acesso!');
      this.router.navigate(['/']);
    }
    const id = this.route.snapshot.paramMap.get('id');
    if (id != undefined && id != null && id != "0") {
      this.edicao = true;
      this.title = "EditarProduto";
      this.produtoService.getById(id).subscribe((f) => {
        this.product = f.data[0];
        console.log(f.data[0]);
      })
    }
  }

  SalvarProduto(): void {
    const prize = this.product.preco ? this.product.preco : 0;
    if (this.product.nm_produto == "" ||
      (prize.toString() == "" || prize == 0)) {
      this.produtoService.showMessage("Os campos  nome e preço são obrigatórios!!");
      return;
    }
    this.produtoService.MostraLoader(true)
    this.product.preco = parseFloat(prize.toString().replace(',','.'));
    
    let userId: string | undefined = localStorage.getItem("UserId")!;
    if (this.edicao) {
      this.product.id_usuario_edicao = userId;
      this.product.dt_edicao = new Date().toISOString();
      this.produtoService.update(this.product).subscribe((f) => {
        this.produtoService.MostraLoader(false)
        this.produtoService.showMessage(f.mensagem);
        if (!f.erro) {
          this.router.navigate(['/produto']);
        }
      })
    } else {
      this.product.id_usuario_criador = userId;
      this.product.id_usuario_edicao = "0";
      this.product.dt_criacao = new Date().toISOString();
      this.produtoService.create(this.product).subscribe((f) => {
        this.produtoService.MostraLoader(false)
        this.produtoService.showMessage(f.mensagem);
        if (!f.erro) {
          this.router.navigate(['/produto']);
        }
      })
    }
  }

  CancelarProduto(): void {
    this.router.navigate(['/produto']);
  }

}
