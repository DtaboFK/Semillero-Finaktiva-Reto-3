import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  title = 'ParkingSmart';

  tarifas = {
    horaCarro: '3.000',
    horaMoto: '1.500',
    diaCarro: '15.000',
    diaMoto: '7.000',
    mesCarro: '100.000',
    mesMoto: '60.000',
  }

  constructor() { }

  ngOnInit(): void {
  }

}
