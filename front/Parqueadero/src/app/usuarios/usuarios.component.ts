import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  showForm(){
    let userInfo = document.getElementById('userInfo');
    let addForm = document.getElementById('addForm');
    let vehicles = document.getElementsByClassName('vehicle');
    userInfo?.classList.toggle('hide');
    addForm?.classList.toggle('hide');
  }

}
