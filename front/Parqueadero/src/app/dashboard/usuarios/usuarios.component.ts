import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IResponse } from 'src/app/interfaces/IResponse';
import { IUsuario } from 'src/app/interfaces/IUsuario';
import { TipoDocumento } from 'src/app/models/TipoDocumento';

import { UsuarioService } from 'src/app/services/usuario/usuario.service';


@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  columnas: string[] = ['Nro', 'Nombre', 'Apellidos', 'Nro. Documento', 'Acciones'];
  searchText!: string;

  typesDNI: TipoDocumento[] = [
    { IdTipoDoc: 1, TipoDoc: 'Tarjeta de indentidad' },
    { IdTipoDoc: 2, TipoDoc: 'Cédula de ciudadanía' },
    { IdTipoDoc: 3, TipoDoc: 'Cédula de extranjería' },
    { IdTipoDoc: 4, TipoDoc: 'Pasaporte' },
  ];

  constructor(public readonly userService: UsuarioService, private builder: FormBuilder) { }

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

  userEditFound!: IUsuario;
  edit: boolean = false;
  deployEdit(doc: string) {
    const user: any = {
      Documento: doc
    }
    this.userService.buscar(user).subscribe(
      (res) => {
        let user = res.data;
        this.size(user, 2);
        this.userEditFound = res.data[0];
        this.edit = true;
        this.editUser = this.initUpdate();
      }
    );
    let listContainer = document.getElementById('lista') as HTMLElement;
    listContainer.classList.toggle('hide');
  }

  editUser!: FormGroup;
  initUpdate(): FormGroup {
    return this.builder.group({
      IdUsuario: [this.userEditFound.idUsuario],
      Nombre: [this.userEditFound.nombre, [Validators.required, Validators.pattern('[A-Za-z]*')]],
      Apellido: [this.userEditFound.apellido, [Validators.required, Validators.pattern('[A-Za-z]*')]],
      FechaNacimiento: [this.userEditFound.fechaNacimiento, Validators.required],
      IdTipoDoc: [this.userEditFound.idTipoDoc, Validators.required],
      Documento: [this.userEditFound.documento, [Validators.required, Validators.pattern('^[0-9]+$')]],
      Contacto: [this.userEditFound.contacto, [Validators.required, Validators.pattern('^[0-9]+$')]],
      Correo: [this.userEditFound.correo, [Validators.required, Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{3,}$')]],
      Direccion: [this.userEditFound.direccion, Validators.required]
    })
  }

  onUpdate() {
    let idUsuario = document.getElementById('editIdUser') as HTMLInputElement;
  }



  // Api response
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
        this.edit = false;
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
