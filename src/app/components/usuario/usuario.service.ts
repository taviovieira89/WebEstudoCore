import { Usuario } from './../../views/usuario/usuario';
import { Login } from './../../views/usuario/login';
import { Result } from './../../views/result';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  baseUrl = "http://localhost:5257/Usuario";

  headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("token"))

  constructor(private sanckbar: MatSnackBar, private http: HttpClient) { }


  create(usuario: Usuario, primeiro: boolean = false): Observable<Result> {
    if (primeiro) {
      const url = this.baseUrl + "/Acesso";
      return this.http.post<Result>(url, usuario, { headers: this.headers })
    } else {
      return this.http.post<Result>(this.baseUrl, usuario, { headers: this.headers })
    }
  }

  update(usuario: Usuario): Observable<Result> {
    return this.http.put<Result>(this.baseUrl, usuario, { headers: this.headers })
  }

  delete(id_usuario: string): Observable<Result> {
    const url = this.baseUrl + "/Exclusao/" + id_usuario;
    return this.http.delete<Result>(url, { headers: this.headers })
  }

  get(): Observable<Result> {
    return this.http.get<Result>(this.baseUrl, { headers: this.headers })
  }

  getById(id_usuario: string): Observable<Result> {
    const url = this.baseUrl + "/GetId/" + id_usuario;
    return this.http.get<Result>(url, { headers: this.headers })
  }

  Logar(usuario: Login): Observable<Result> {
    const url = this.baseUrl + "/Login";
    return this.http.post<Result>(url, usuario, { headers: this.headers })
  }

  PrimeiroAcesso(usuario: Usuario): Observable<Result> {
    const url = this.baseUrl + "/Acesso";
    return this.http.post<Result>(url, usuario, { headers: this.headers })
  }

  showMessage(msg: string): void {
    this.sanckbar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }

  MostraLoader(visible: boolean) {
    const head = document.querySelector<HTMLElement>('#divloading')!;
    head.style.display = visible ? "block" : "none";
  }


}
