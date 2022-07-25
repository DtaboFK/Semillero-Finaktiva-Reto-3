import { Component, OnInit } from '@angular/core';
import { IUsuario } from 'src/app/interfaces/IUsuario';
import { UsuarioModal, UsuarioService } from 'src/app/services/usuario/usuario.service';


@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  usuarios!: any;
  userFound!: any;
  columnas: string[] = ['Nro','Nombre','Apellidos','Nro. Documento','Acciones'];

  constructor(public userService : UsuarioService, private modal : UsuarioModal) { }

  ngOnInit(): void {
    this.userService.listar().subscribe(
      res => this.usuarios = res
    );
  }

  /*ngOnInit() : void {
    this.userService.listar().subscribe(
      // response => console.log(response)
      response => this.usuarios = response
    );
    this.modal.$modal.subscribe(valor => {
      this.modalSwitch = valor
    });
  }*/

  modalSwitch : boolean = false;
  addUser(turn : boolean) {
    this.modalSwitch = turn;
  }

  buscar() { // Exaple 10101010
    let doc = document.getElementById('search') as HTMLInputElement;
    const user = {
      documento: doc.value
    }
    this.userService.buscar(user).subscribe(
      // result => console.log(result)
      result => this.userFound = result
    );
    doc.value = '';
  }

  

}
