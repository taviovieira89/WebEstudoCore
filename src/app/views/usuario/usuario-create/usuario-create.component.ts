import { Usuario } from './../usuario';
import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/components/usuario/usuario.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-usuario-create',
  templateUrl: './usuario-create.component.html',
  styleUrls: ['./usuario-create.component.css']
})
export class UsuarioCreateComponent implements OnInit {
  edicao: boolean = false;
  user: Usuario = {
    nm_usuario: '',
    dt_nascimento: '',
    login: '',
    senha: ''
  }

  title: string = "Novo Usuário";
  ehPrimeiro: boolean = false;

  constructor(private usuarioService: UsuarioService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {

    var primeiroacesso = localStorage.getItem("primeiroacesso");
    var vprimerioacesso = primeiroacesso != undefined && primeiroacesso != null;
    if (vprimerioacesso) {
      localStorage.removeItem("primeiroacesso");
      this.ehPrimeiro = true;
    }

    if (!vprimerioacesso && (localStorage.getItem("token") == undefined || localStorage.getItem("token") == null)) {
      this.usuarioService.showMessage('Sem premissão de acesso!');
      this.router.navigate(['/']);
    }

    const id = this.route.snapshot.paramMap.get('id');
    if (id != undefined && id != null && id != "0") {
      this.edicao = true;
      this.title = "Editar Usuário";
      this.usuarioService.getById(id).subscribe((f) => {
        if (f.data.length > 0) {
          this.user = f.data[0];
          var data = this.user.dt_nascimento ?? "";
          var ano = data.substring(0, 4)
          var mes = data.substring(5, 7)
          var dia = data.substring(8, 10)
          var dtNasc = dia + "/" + mes + "/" + ano;
          this.user.dt_nascimento = dtNasc;
          console.log(f.data[0]);
        }
      })
    }
  }

  MascaraData(): void {
    var data = this.user.dt_nascimento ?? "";
    if (data.length == 2 || data.length == 5) {
      this.user.dt_nascimento = data + "/";
    }
  }

  SalvarUsuario(): void {

    if (this.user.dt_nascimento == "" ||
      this.user.nm_usuario == "" ||
      this.user.login == "" ||
      this.user.senha == "") {
      this.usuarioService.showMessage("Os campos data nascimento, nome, login e senha são obrigatórios!!");
      return;
    }
    this.usuarioService.MostraLoader(true)
    var dt_nascimento = this.user.dt_nascimento;
    var dia = dt_nascimento?.substring(0, 2);
    var mes = dt_nascimento?.substring(3, 5);
    var ano = dt_nascimento?.substring(6, 10);
    var dataNasc = ano + "-" + mes + "-" + dia + "T00:00:00.000Z";
    this.user.dt_nascimento = dataNasc;

    if (this.edicao) {
      this.usuarioService.update(this.user).subscribe((f) => {
        this.usuarioService.MostraLoader(false)
        this.usuarioService.showMessage(f.mensagem);
        if (!f.erro) {
          this.router.navigate(['/usuario']);
        }
      })
    } else {
      this.usuarioService.create(this.user, this.ehPrimeiro).subscribe((f) => {
        this.usuarioService.MostraLoader(false)
        this.usuarioService.showMessage(f.mensagem);
        if (!f.erro) {
          if (this.ehPrimeiro) {
            this.router.navigate(['/']);
          } else {
            this.router.navigate(['/usuario']);
          }
        }
      })
    }
  }

  CancelarUsuario(): void {
    if (this.ehPrimeiro) {
      this.router.navigate(['/']);
    } else {
      this.router.navigate(['/usuario']);
    }
  }

}
