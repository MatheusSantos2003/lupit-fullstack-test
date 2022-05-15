import { TimesService } from './../shared/services/times.service';
import { Component, OnInit } from '@angular/core';
import Time from '../shared/models/Time.model';

@Component({
  selector: 'app-times',
  templateUrl: './times.component.html',
  styleUrls: ['./times.component.css']
})
export class TimesComponent implements OnInit {

  ListaTime: Time[] = [];
  isLoading:boolean = false;

  constructor(private _timeService: TimesService) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.obterJogadores();
  }

  Editar() {
    alert("Editei");
  }

  Excluir() {
    alert("exclui");
  }

  obterJogadores(){
    this._timeService.ListarTimes().subscribe((res)=>{
      if(res.sucesso){
        this.ListaTime = res.resultado;
        this.isLoading = false
      }else{
        this.isLoading= false;
      }
    });
  }
}
