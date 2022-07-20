import { Component } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  doc: string = '';
  pass: string = ''

  constructor(private router: Router) { }

  login(){
    const operario = {
      documento: this.doc,
      clave: this.pass
    };
    console.log(operario);
    this.router.navigate(['/dashboard']);
  };

}
