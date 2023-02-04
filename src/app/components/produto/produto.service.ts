import { Produto } from './../../views/produto/produto';
import { Result } from './../../views/result';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  baseUrl = "http://localhost:5257/Produto";

  headers = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("token"))

  constructor(private sanckbar: MatSnackBar, private http: HttpClient) { }


  create(produto: Produto): Observable<Result> {
    return this.http.post<Result>(this.baseUrl, produto, { headers: this.headers })
  }

  update(produto: Produto): Observable<Result> {
    return this.http.put<Result>(this.baseUrl, produto, { headers: this.headers })
  }

  delete(id_produto: string): Observable<Result> {
    const url = this.baseUrl + "/Exclusao/" + id_produto;
    return this.http.delete<Result>(url, { headers: this.headers })
  }

  get(): Observable<Result> {
    return this.http.get<Result>(this.baseUrl, { headers: this.headers })
  }

  getById(id_produto: string): Observable<Result> {
    const url = this.baseUrl + "/GetId/" + id_produto;
    return this.http.get<Result>(url, { headers: this.headers })
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
