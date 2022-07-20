import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
  providedIn: 'root'
})
export class OperarioService {

  constructor(private http: HttpClient) { }

  url: string = 'https://localhost:44350/Operario/Login';

  login(user: any): Observable<any> {
    return this.http.post(this.url, user);
  }

}
