import { Component } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { Router } from '@angular/router';

export interface DNI {
  value: string,
  viewValue: string
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  name: string = '';
  lastName: string = '';
  selected: string = 'Seleccione un tipo de documento . . .';
  doc: string = '';
  pass: string = '';

  constructor(private router: Router) { }

  typesDNI: DNI[] = [
    { value: '1', viewValue: 'Tarjeta de indentidad' },
    { value: '2', viewValue: 'Cédula de ciudadanía' },
    { value: '3', viewValue: 'Cédula de extranjería' },
    { value: '4', viewValue: 'Pasaporte' },
  ];

  signUp(){
    const operario = {
      Nombre: this.name,
      Apellido: this.lastName,
      IdTipoDoc: this.selected,
      Documento: this.doc,
      Clave: this.pass
    }
    console.log(operario);
    this.router.navigate(['/login']);
  }

}
