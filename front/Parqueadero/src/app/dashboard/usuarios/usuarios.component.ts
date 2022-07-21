import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';
import { Usuario } from "../../models/Usuario";
import { TipoDocumento } from "../../models/TipoDocumento";

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {
  
  typesDNI: TipoDocumento[] = [
    { IdTipoDoc: 1, TipoDoc: 'Tarjeta de indentidad' },
    { IdTipoDoc: 2, TipoDoc: 'Cédula de ciudadanía' },
    { IdTipoDoc: 3, TipoDoc: 'Cédula de extranjería' },
    { IdTipoDoc: 4, TipoDoc: 'Pasaporte' },
  ];

  name: string = '';
  lastNames: string = '';
  birthDate: string = '';
  selected: string = 'Seleccione un tipo de documento . . .';
  doc: string = '';
  contact: string = '';
  email: string = '';
  address: string = '';

  // usuarios: Usuario = new Usuario;
  usuarios : any; 
  userFound : Usuario[] = [];
  // userFound : any;

  constructor(private router : Router, public userService : UsuarioService) { }

  ngOnInit() {
    this.userService.listar().subscribe(
      // response => console.log(response)
      // response => this.info = response
      response => this.usuarios = response
    );
    
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

  signUpUser(){
    const user = {
      Nombre: this.name,
      Apellido: this.lastNames,
      FechaNacimiento: this.birthDate,
      IdTipoDoc: this.selected,
      Documento: this.doc,
      Contacto: this.contact,
      Correo: this.email,
      Direccion: this.address
    }
    console.log(user);
    this.router.navigate(['/home']);
  }

}
