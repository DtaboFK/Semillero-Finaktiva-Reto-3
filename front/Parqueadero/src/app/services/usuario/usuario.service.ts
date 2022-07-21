import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from "../../models/Usuario";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  uriListar: string = 'https://localhost:44350/Usuario/Listar';
  uriBuscar: string = 'https://localhost:44350/Usuario/Buscar';

  constructor(private http: HttpClient) {}

  listar() : Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.uriListar);
  }

  buscar(user : any) : Observable<any> {
    return this.http.post(this.uriBuscar, user);
  }

}
