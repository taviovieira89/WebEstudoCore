import { UsuarioCreateComponent } from './views/usuario/usuario-create/usuario-create.component';
import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { ProdutoComponent } from './views/produto/produto.component';
import { UsuarioComponent } from './views/usuario/usuario.component';
import { ProdutoCreateComponent } from './views/produto/produto-create/produto-create.component';
import { UsuarioLoginComponent } from './views/usuario/usuario-login/usuario-login.component';

const routes: Routes = [
  {
    path: "",
    component: UsuarioLoginComponent
  },
  {
    path: "home",
    component: HomeComponent
  },
  {
    path: "produto",
    component: ProdutoComponent
  },
  {
    path: "usuario",
    component: UsuarioComponent
  },
  {
    path: "produto/create",
    component: ProdutoCreateComponent
  },
  {
    path: "produto/create/:id",
    component: ProdutoCreateComponent
  },
  {
    path: "usuario/create",
    component: UsuarioCreateComponent
  },
  {
    path: 'usuario/create/:id',
    component: UsuarioCreateComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
