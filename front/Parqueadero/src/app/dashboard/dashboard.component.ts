import { Component, OnInit } from '@angular/core';
import { IResponse } from '../interfaces/IResponse';
import { ApiService } from '../services/communication/api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  title = 'ParkingSmart';
  apiMsg!: string;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.$com.subscribe(
      (valor) => {
        this.apiMsg = valor.header.message;
        this.showMsg(valor);
      }
    );
  }

  showMsg(response: IResponse) {
    let code: number = response.header.code;
    let msgContainer = document.getElementById('mgs') as HTMLElement;
    let clase: string;
    let time: number = 4000;
    switch (code) {
      case 200:
        clase = 'successMessage';
        setTimeout(() => {
          msgContainer.classList.add(clase);
          msgContainer.classList.toggle('hide');
          this.hideMsg(time, clase);
        }, 1000);
        
        break;

      case 422:
        clase = 'dangerMessage';
        setTimeout(() => {
          msgContainer.classList.add(clase);
          msgContainer.classList.toggle('hide');
          this.hideMsg(time, clase);
        }, 1000);
        
        break;

      case 404:
        clase = 'warnMessage';
        setTimeout(() => {
          msgContainer.classList.add(clase);
          msgContainer.classList.toggle('hide');
          this.hideMsg(time, clase);
        }, 1000);
        
        break;

      default:
        clase = 'infoMessage';
        setTimeout(() => {
          msgContainer.classList.add(clase);
          msgContainer.classList.toggle('hide');
          this.hideMsg(time, clase);
        }, 1000);
        
        break;
    }
  }

  hideMsg(timer: number, clase: string) {
    let msgContainer = document.getElementById('mgs') as HTMLElement;
    setTimeout(() => {
      msgContainer.classList.remove(clase);
      this.apiMsg = '';
    }, timer);
  }

  option: string = 'usuario';
  desplegar(opt: string) {

    if (opt == this.option) {
      this.option = '';
    } else {
      this.option = opt;
    }

  }

}
