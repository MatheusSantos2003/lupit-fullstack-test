import { JogadoresService } from './../shared/services/jogadores.service';
import { TimesService } from './../shared/services/times.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import Time from '../shared/models/Time.model';
import Jogador from './../shared/models/Jogador.model';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-cadastro-jogador',
  templateUrl: './cadastro-jogador.component.html',
  styleUrls: ['./cadastro-jogador.component.css']
})
export class CadastroJogadorComponent implements OnInit {

  public submitted:boolean = false;
  public isLoading:boolean = true;
  public formulario: FormGroup;
  public listaTimes:Time[] = [];

  constructor( private formBuild: FormBuilder, private _timeService:TimesService,private _jogadorService: JogadoresService ) {
    this.formulario = this.formBuild.group({
      nome: ["",Validators.required],
      idade: [null,Validators.required],
      time: [null,Validators.required]
    })

   }

  ngOnInit(): void {
    this._timeService.ListarTimes().subscribe((res)=>{
      if(res.sucesso){
        this.listaTimes = res.resultado;
        this.isLoading = false;
      }
    });

  }



  OnSubmit(){
    let jogador:Jogador = new Jogador();
    this.submitted = true;
    jogador.name = this.formulario.controls['nome'].value;
    jogador.age = this.formulario.controls['idade'].value;
    jogador.time_id = this.formulario.controls['time'].value;

   this._jogadorService.CadastrarJogador(jogador).subscribe((res)=>{

    if(res.sucesso){
      Swal.fire<boolean>("Sucesso!", "Cadastrado Com sucesso!", 'success');
      this.submitted = false;
      this.isLoading = false;
      this.formulario.reset();
    }else{
      Swal.fire<boolean>("Erro!", "Houve um Erro ao Cadastrar um Jogador!", 'error');
      this.isLoading = false;
      console.log(res);
    }

   });

  }


}
