import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { Ng2SearchPipeModule } from "ng2-search-filter";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './home/login/login.component';
import { PageNotFoundComponent } from './home/page-not-found/page-not-found.component';
import { RegisterComponent } from './home/register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsuariosComponent } from './dashboard/usuarios/usuarios.component';

import { UsuarioService } from './services/usuario/usuario.service';
import { ModalRegistroComponent } from './dashboard/usuarios/usuario-registro/usuario-registro.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'dashboard', component: DashboardComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    PageNotFoundComponent,
    RegisterComponent,
    DashboardComponent,
    UsuariosComponent,
    ModalRegistroComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule
  ],
  providers: [
    UsuarioService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
