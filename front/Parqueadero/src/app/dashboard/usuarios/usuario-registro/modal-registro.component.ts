import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { TipoDocumento } from "../../../models/TipoDocumento";

import { UsuarioModal } from 'src/app/services/usuario/usuario.service';

@Component({
  selector: 'app-modal-registro',
  templateUrl: './modal-registro.component.html',
  styleUrls: ['./modal-registro.component.css']
})
export class ModalRegistroComponent implements OnInit {

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

  constructor(private router : Router, private modalService : UsuarioModal) { }

  ngOnInit(): void {
  }

  closeModal() {
    this.modalService.$modal.emit(false);
  }

  vehicleSelected(vehicle : string) {
    if (vehicle === 'car') {
      let car = document.getElementById('car') as HTMLElement;
      car.classList.toggle('active');
      let bike = document.getElementById('bike') as HTMLElement;
      bike.classList.remove('active');
    } else {
      let bike = document.getElementById('bike') as HTMLElement;
      bike.classList.toggle('active');
      let car = document.getElementById('car') as HTMLElement;
      car.classList.remove('active');
    }
  }

  signUpUser() {
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
    // this.router.navigate(['/home']);
  }

}
