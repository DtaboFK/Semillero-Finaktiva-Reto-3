import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IResponse } from 'src/app/interfaces/IResponse';
import { IUsuario } from 'src/app/interfaces/IUsuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  uriListar: string = 'https://localhost:44350/Usuario/Listar';
  uriBuscar: string = 'https://localhost:44350/Usuario/Buscar';
  uriCrear: string = 'https://localhost:44350/Usuario/Crear';
  uriActualizar: string = 'https://localhost:44350/Usuario/Actualizar';

  constructor(private http: HttpClient) { }

  listar(): Observable<IResponse> {
    return this.http.get<IResponse>(this.uriListar);
  }

  buscar(user: any): Observable<IResponse> {
    return this.http.post<IResponse>(this.uriBuscar, user);
  }

  registrar(user: any): Observable<IResponse> {
    return this.http.post<IResponse>(this.uriCrear, user);
  }

  actualizar(user: any): Observable<IResponse> {
    return this.http.put<IResponse>(this.uriActualizar,user);
  }

}