import { Component, OnInit } from '@angular/core';
import { UsuarioModal, UsuarioService } from 'src/app/services/usuario/usuario.service';


@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  // usuarios: Usuario = new Usuario;
  usuarios : any; 
  // userFound : Usuario[] = [];
  userFound : any;

  constructor(public userService : UsuarioService, private modal : UsuarioModal) { }

  ngOnInit() {
    this.userService.listar().subscribe(
      // response => console.log(response)
      // response => this.info = response
      response => this.usuarios = response
    );
    this.modal.$modal.subscribe(valor => {
      this.modalSwitch = valor
    });
  }

  modalSwitch : boolean = true;
  addUserModal(turn : boolean) {
    this.modalSwitch = turn;
  }

  buscar() { // Exaple 1010101010
    let doc = document.getElementById('search') as HTMLInputElement;
    console.log(doc.value);
    const user = {
      documento: doc.value
    }
    console.log(user);
    this.userService.buscar(user).subscribe(
      // result => console.log(result)
      result => this.userFound = result
    );
    doc.value = '';
  }

  

}
