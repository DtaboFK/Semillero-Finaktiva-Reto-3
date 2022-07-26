import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { IResponse } from 'src/app/interfaces/IResponse';
import { IUsuario } from 'src/app/interfaces/IUsuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  uriListar: string = 'https://localhost:44350/Usuario/Listar';
  uriBuscar: string = 'https://localhost:44350/Usuario/Buscar';
  uriCrear: string = 'https://localhost:44350/Usuario/Crear';

  constructor(private http: HttpClient) { }

  listar(): Observable<IUsuario[]> {
    return this.http.get<IUsuario[]>(this.uriListar);
  }

  buscar(user: any): Observable<IUsuario[]> {
    return this.http.post<IUsuario[]>(this.uriBuscar, user);
  }

  registrar(user: any): Observable<IResponse> {
    return this.http.post<IResponse>(this.uriCrear, user);
  } 

}