import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  login!: FormGroup;

  constructor(private readonly builder: FormBuilder , private router: Router) { }

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
    console.log(this.login.value);
    this.router.navigate(['dashboard'])
  }

}
