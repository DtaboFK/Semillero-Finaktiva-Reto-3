import { Component, EventEmitter, OnInit, Output } from '@angular/core';

import { TipoDocumento } from "../../../models/TipoDocumento";

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';
import { IResponse } from 'src/app/interfaces/IResponse';

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

  constructor(private readonly fb: FormBuilder, private userService: UsuarioService) { }

  ngOnInit(): void {
    this.addUser = this.initForm();
  }

  initForm(): FormGroup {
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

  result!: IResponse;
  onSubmit() {
    this.userService.registrar(this.addUser.value).subscribe(
      res => console.log(res)
      
      
      // res => this.result = res
        // res => console.log(res)
        
      // () => {
      //   console.log(res);
      //   // console.log(res.header);
      //   // console.log(res.code);
      //   this.result = res;

      //   if (res.code == 200) {
      //     this.propagar.emit('Cliente registrado con éxito');
      //   } else if (res.code == 400) {
      //     this.propagar.emit('Cliente no registrado');
      //   }
      // }
    )
    // this.propagar.emit('hideAddForm');
  }



  // Navegabilidad
  @Output() propagar = new EventEmitter<string>();

  next() {

  }

  back() {
    this.propagar.emit('hideAddForm');
  }

}
