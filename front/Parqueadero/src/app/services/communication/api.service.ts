import { EventEmitter, Injectable } from '@angular/core';
import { IResponse } from "../../interfaces/IResponse";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor() { }

  $com = new EventEmitter<IResponse>();

}
