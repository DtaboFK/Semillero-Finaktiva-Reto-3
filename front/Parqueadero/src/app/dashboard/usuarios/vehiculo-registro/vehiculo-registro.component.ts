import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehiculo-registro',
  templateUrl: './vehiculo-registro.component.html',
  styleUrls: ['./vehiculo-registro.component.css']
})
export class VehiculoRegistroComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  vehicleSelected(vehicle : string) {
    if (vehicle === 'car') {
      let car = document.getElementById('car') as HTMLElement;
      car.classList.toggle('active');
      let bike = document.getElementById('bike') as HTMLElement;
      bike.classList.remove('active');
    } else {
      let bike = document.getElementById('bike') as HTMLElement;
      bike.classList.toggle('active');
      let car = document.getElementById('car') as HTMLElement;
      car.classList.remove('active');
    }
  }

}
