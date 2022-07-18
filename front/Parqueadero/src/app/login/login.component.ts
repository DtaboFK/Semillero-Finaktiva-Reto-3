import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  showSignUp(){
    let loginBox = document.getElementById('loginBox');
    let signUpForm = document.getElementById('signUpForm');
    loginBox?.classList.toggle('hide');
    signUpForm?.classList.toggle('hide');
  }

}
