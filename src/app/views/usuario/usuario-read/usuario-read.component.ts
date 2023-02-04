import { Observable } from 'rxjs';
import { Usuario } from './../usuario';
import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/components/usuario/usuario.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-usuario-read',
  templateUrl: './usuario-read.component.html',
  styleUrls: ['./usuario-read.component.css']
})
export class UsuarioReadComponent {
  users: Usuario[]
  displayedColumns = ['id_usuario', 'nm_usuario','dt_nascimento' ,'login', 'action']

  constructor(private usuarioService: UsuarioService, private router: Router, private sanckbar: MatSnackBar) { }

  ngOnInit(): void {
    if (localStorage.getItem("token") == undefined || localStorage.getItem("token") == null) {
      this.usuarioService.showMessage('Sem premissão de acesso!');
      this.router.navigate(['/']);
    }

    this.usuarioService.get().subscribe((f) => {
      this.users = f.data;
      console.log(f.data);
    })
  }

  Excluir(id: string): void {
    var alert = window.confirm('Deseja realiza a exclusão?');
    if (alert) {
      this.usuarioService.MostraLoader(true)
      this.usuarioService.delete(id).subscribe((f) => {
        this.usuarioService.MostraLoader(false)
        this.usuarioService.showMessage(f.mensagem);
        this.router.navigate(['/usuario']);
      })
    }
  }

}
