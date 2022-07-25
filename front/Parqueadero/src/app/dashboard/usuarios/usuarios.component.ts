import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UsuarioModal, UsuarioService } from 'src/app/services/usuario/usuario.service';


@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  usuarios!: any;
  columnas: string[] = ['Nro', 'Nombre', 'Apellidos', 'Nro. Documento', 'Acciones'];
  searchText!: string;

  constructor(public userService: UsuarioService, private modal: UsuarioModal, private router : Router) { }

  ngOnInit(): void {
    this.userService.listar().subscribe(
      res => this.usuarios = res
    );
    this.modal.$modal.subscribe(valor => {
      this.modalSwitch = valor
    });
  }

  modalSwitch: boolean = false;
  addUser(turn: boolean) {
    this.modalSwitch = turn;
  }

  userFound!: any;
  buscar(doc: string) {
    const user: any = {
      Documento: doc
    }
    this.userService.buscar(user).subscribe(
      res => this.userFound = res
      // res => console.log(res)
    );
    let lista = document.getElementById('lista');
    lista?.classList.toggle('hide');
  }

  // Presentación de datos
  showDoc(num: number) {
    switch (num) {
      case 1:
        return 'Tarjeta de identidad';
        break;

      case 2:
        return 'Cédula de ciudadanía';
        break;

      case 3:
        return 'Cédula de extranjería';
        break;

      case 4:
        return 'Pasaporte';
        break;
      default:
        return 'NA'
        break;
    }
  }

  snipDate(date: string){
    let newDate = date.split("T",1);
    return newDate;
  }

  goBack() {
    this.router.navigate(['/dashboard']);
  }

}
