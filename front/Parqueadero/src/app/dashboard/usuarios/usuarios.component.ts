import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

export interface DNI {
  value: string,
  viewValue: string
}

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {
  [x: string]: any;

  name: string = '';
  lastNames: string = '';
  birthDate: string = '';
  selected: string = 'Seleccione un tipo de documento . . .';
  doc: string = '';
  contact: string = '';
  email: string = '';
  address: string = '';

  constructor(private router : Router) { }

  typesDNI: DNI[] = [
    { value: '1', viewValue: 'Tarjeta de indentidad' },
    { value: '2', viewValue: 'Cédula de ciudadanía' },
    { value: '3', viewValue: 'Cédula de extranjería' },
    { value: '4', viewValue: 'Pasaporte' },
  ];

  ngOnInit(): void {
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
