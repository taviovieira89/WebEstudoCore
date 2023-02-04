import { Component, OnInit } from '@angular/core';
import { Login } from '../login';
import { UsuarioService } from 'src/app/components/usuario/usuario.service';
import { Router } from '@angular/router';
'./assets'

@Component({
  selector: 'app-usuario-login',
  templateUrl: './usuario-login.component.html',
  styleUrls: ['./usuario-login.component.css']
})
export class UsuarioLoginComponent implements OnInit {

  user: Login = {
    login: '',
    senha: ''
  }

  constructor(private usuarioService: UsuarioService, private router: Router) { }

  ngOnInit(): void {
    localStorage.removeItem("token");
    this.HabilitarMenus(true);
  }

  HabilitarMenus(valida: boolean): void {
    var display = valida ? "none" : "";
    const elm = document.querySelector<HTMLElement>('.footer')!;
    elm.style.display = display;
    const head = document.querySelector<HTMLElement>('#Header01')!;
    head.style.display = display;
    const nav = document.querySelector<HTMLElement>('#Nav01')!;
    nav.style.display = display;
  }

  Logar(): void {
    this.usuarioService.MostraLoader(true)
    if (this.user.login != "" && this.user.senha != "") {
      this.usuarioService.Logar(this.user).subscribe((f) => {

        if (!f.erro) {
          var userid = f.data[0];
          var token = f.data[1];
          localStorage.setItem("token", token)
          localStorage.setItem("UserId", userid)
          this.HabilitarMenus(false);
          this.usuarioService.MostraLoader(false)
          this.router.navigate(['/home']);
        } else {
          this.usuarioService.MostraLoader(false)
          this.usuarioService.showMessage(f.mensagem);
        }
      })
    } else {
      this.usuarioService.MostraLoader(false)
      this.usuarioService.showMessage("Por favor informar o login e senha!");
    }

  }

  RedirectAcesso(): void {
    localStorage.setItem("primeiroacesso", "1");
    this.router.navigate(['/usuario/create']);
  }

}
