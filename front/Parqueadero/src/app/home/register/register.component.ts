import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ITipoDocumento } from 'src/app/interfaces/ITipoDocumento';
import { OperarioService } from 'src/app/services/operario/operario.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerOperario !: FormGroup;

  tiposDoc: ITipoDocumento[] = [
    { IdTipoDoc: 1, TipoDoc: 'Tarjeta de indentidad' },
    { IdTipoDoc: 2, TipoDoc: 'Cédula de ciudadanía' },
    { IdTipoDoc: 3, TipoDoc: 'Cédula de extranjería' },
    { IdTipoDoc: 4, TipoDoc: 'Pasaporte' },
  ]

  constructor(private readonly builder: FormBuilder, private readonly router : Router, private opServ: OperarioService) { }

  ngOnInit(): void {
    this.registerOperario = this.initForm();
  }

  initForm(): FormGroup {
    return this.builder.group({
      Nombre: ['', [Validators.required, Validators.pattern('[A-Za-z]*')]],
      Apellido: ['', [Validators.required, Validators.pattern('[A-Za-z]*')]],
      IdTipoDoc: ['Seleccione un tipo de documento . . .', Validators.required],
      Documento: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      Clave: ['', [Validators.required, Validators.minLength(8)]]
    })
  }

  onSubmit(): void {
    // console.log(this.registerOperario.value);
    this.opServ.register(this.registerOperario.value).subscribe(
      res => console.log(res)
    );
    this.router.navigate(['login']);
  }

}