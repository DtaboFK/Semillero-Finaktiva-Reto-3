import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  title = 'ParkingSmart';

  option : string = 'usuario';

  constructor() { }

  ngOnInit() : void {
  }

  desplegar(opt : string){
    
    if (opt == this.option) {
      this.option = '';  
    } else {
      this.option = opt;
    }
    
  }

}
