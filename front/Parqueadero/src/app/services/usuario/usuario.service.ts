import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { IUsuario } from 'src/app/interfaces/IUsuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  uriListar: string = 'https://localhost:44350/Usuario/Listar';
  uriBuscar: string = 'https://localhost:44350/Usuario/Buscar';

  constructor(private http: HttpClient) { }

  listar(): Observable<IUsuario[]> {
    return this.http.get<IUsuario[]>(this.uriListar);
  }

  buscar(user: any): Observable<IUsuario[]> {
    return this.http.post<IUsuario[]>(this.uriBuscar, user);
  }

}

export class UsuarioModal {

  constructor() { }

  $modal = new EventEmitter<any>();

}