import { Component, OnInit } from '@angular/core';

import { TipoDocumento } from "../../../models/TipoDocumento";

import { UsuarioModal } from 'src/app/services/usuario/usuario.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-modal-registro',
  templateUrl: './usuario-registro.component.html',
  styleUrls: ['./usuario-registro.component.css']
})
export class ModalRegistroComponent implements OnInit {

  addUser!: FormGroup;
  
  typesDNI: TipoDocumento[] = [
    { IdTipoDoc: 1, TipoDoc: 'Tarjeta de indentidad' },
    { IdTipoDoc: 2, TipoDoc: 'Cédula de ciudadanía' },
    { IdTipoDoc: 3, TipoDoc: 'Cédula de extranjería' },
    { IdTipoDoc: 4, TipoDoc: 'Pasaporte' },
  ];

  constructor(private modalService : UsuarioModal, private readonly fb : FormBuilder) { }

  ngOnInit(): void {
    this.addUser = this.initForm();
  }

  turnBack() {
    this.modalService.$modal.emit(false);
  }

  next() {
    
  }

  initForm() : FormGroup {
    return this.fb.group({
      Nombre: ['', [Validators.required, Validators.pattern('[A-Za-z]*')]],
      Apellido: ['', [Validators.required, Validators.pattern('[A-Za-z]*')]],
      FechaNacimiento: ['', Validators.required],
      IdTipoDoc: ['Seleccione un tipo de documento . . .', Validators.required],
      Documento: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      Contacto: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      Correo: ['', [Validators.required, Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{3,}$')]],
      Direccion: ['', Validators.required]
    })
  }

  onSubmit(): void {
    console.log(this.addUser.value);
  }

}
