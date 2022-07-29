import { Component, OnInit } from '@angular/core';
import { IResponse } from 'src/app/interfaces/IResponse';
import { IUsuario } from 'src/app/interfaces/IUsuario';

import { UsuarioService } from 'src/app/services/usuario/usuario.service';


@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  
  columnas: string[] = ['Nro', 'Nombre', 'Apellidos', 'Nro. Documento', 'Acciones'];
  searchText!: string;

  constructor(public readonly userService: UsuarioService) { }

  result!: IResponse;
  lista!: IUsuario[];
  ngOnInit(): void {
    this.userService.listar().subscribe(
      (res) => {
        this.lista = res.data;
        this.size(this.lista, 1);
        this.result = res;
      }
    );
  }

  long!: number;
  size(lista: IUsuario[], opt: number) {
    if (opt == 1) {
      this.long = lista.length;
    } else {
      this.userLong = lista.length;
    }
  }

  // Funciones CRUD
  listar() {
    this.userService.listar().subscribe(
      res => this.lista = res.data
      // res => console.log(res)
      
    );
  }

  userFound!: IUsuario;
  userLong!: number;
  buscar(doc: string) {
    const user: any = {
      Documento: doc
    }
    this.userService.buscar(user).subscribe(
      // res => this.userFound = res
      (res) => {
        let user = res.data;
        this.size(user, 2);
        this.userFound = res.data[0];
      }
    );
    let listContainer = document.getElementById('lista') as HTMLElement;
    listContainer.classList.toggle('hide');
  }

  apiRes!: IResponse;
  apiResponse(response: IResponse) {
    this.apiRes.header = response.header;
  }

  // Presentación de datos
  showDoc(num: number) {
    switch (num) {
      case 1:
        return 'Tarjeta de identidad';

      case 2:
        return 'Cédula de ciudadanía';

      case 3:
        return 'Cédula de extranjería';

      case 4:
        return 'Pasaporte';
      default:
        return 'NA';
    }
  }

  snipDate(date: string) {
    let newDate = date.split("T", 1);
    return newDate;
  }

  // Navegabilidad

  optionSwitch: string = '';

  desplegar(opt: string): void {
    let lista = document.getElementById('lista');
    let addForm = document.getElementById('addForm');
    let main = document.getElementById('main');

    // this.optionSwitch = opt : string;

    switch (opt) {
      case 'addUser':
        main?.classList.toggle('hide');
        lista?.classList.toggle('hide');
        addForm?.classList.toggle('hide');
        break;

      case 'btnBack':
        this.userLong = 0;
        this.listar();
        lista?.classList.toggle('hide');
        break;

      case 'hideAddForm':
        addForm?.classList.toggle('hide');
        lista?.classList.toggle('hide');
        main?.classList.toggle('hide');
        this.listar();
        break;

      default:
        break;
    }
  }

}
