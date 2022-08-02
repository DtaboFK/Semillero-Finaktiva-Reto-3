import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { OperarioService } from 'src/app/services/operario/operario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  login!: FormGroup;

  constructor(private readonly builder: FormBuilder , private router: Router, private opServ: OperarioService) { }

  ngOnInit(): void {
    this.login = this.initLogin();
  }

  initLogin(): FormGroup {
    return this.builder.group({
      Documento: ['', [Validators.required,Validators.pattern('^[0-9]+$')]],
      Clave: ['', Validators.required]
    })
  }


  onLogin(): void {
    this.opServ.login(this.login.value).subscribe(
      res => console.log(res)
    );
    console.log(this.login.value);
    this.router.navigate(['dashboard'])
  }

}
