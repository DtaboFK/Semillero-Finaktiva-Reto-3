import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/internal/Observable";
import { IResponse } from 'src/app/interfaces/IResponse';

@Injectable({
  providedIn: 'root'
})
export class OperarioService {

  constructor(private http: HttpClient) { }

  uriLogin: string = 'https://localhost:44350/Operario/Login';
  uriCrear: string = 'https://localhost:44350/Operario/Crear';

  login(user: any): Observable<IResponse> {
    return this.http.post<IResponse>(this.uriLogin, user);
  }

  register(user:any): Observable<IResponse> {
    return this.http.post<IResponse>(this.uriCrear, user);
  }

}
