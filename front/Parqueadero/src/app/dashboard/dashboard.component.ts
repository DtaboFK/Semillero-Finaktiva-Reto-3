import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  title = 'ParkingSmart';

  option : string = '';

  constructor() { }

  ngOnInit() : void {
  }

  desplegar(opcion : string){
    this.option = opcion;
  }

}
