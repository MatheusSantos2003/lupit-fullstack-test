import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import Swal from 'sweetalert2';
import Jogador from '../shared/models/Jogador.model';
import Time from '../shared/models/Time.model';
import { JogadoresService } from '../shared/services/jogadores.service';
import { TimesService } from '../shared/services/times.service';

@Component({
  selector: 'app-editar-jogador',
  templateUrl: './editar-jogador.component.html',
  styleUrls: ['./editar-jogador.component.css']
})
export class EditarJogadorComponent implements OnInit {

  public submitted:boolean = false;
  public isLoading:boolean = true;
  public formulario!: FormGroup;
  public listaTimes:Time[] = [];
  public JogadorEdit:Jogador = new Jogador();
   id!:number;

   public time_select?:Time = new Time();
  constructor(
    private formBuild: FormBuilder,
    private _timeService:TimesService,
    private _jogadorService: JogadoresService,
    private route: ActivatedRoute ) {

       this.formulario = this.formBuild.group({
          id: [null,Validators.required],
          nome: ["",Validators.required],
          idade: [null,Validators.required],
          time: [null,Validators.required]
        });


   }



   setupFormJogador(jogador:Jogador){
    this.formulario?.controls['id'].setValue(jogador.id);
    this.formulario?.controls['nome'].setValue(jogador.name);
    this.formulario?.controls['idade'].setValue(jogador.age);
    this.formulario?.controls['time'].setValue(this.time_select);

   }



  ngOnInit(): void {

    this.id = this.route.snapshot.params['id'];

    this._jogadorService.BuscarJogador(this.id).subscribe((res)=>{
        if(res.sucesso){
          this.JogadorEdit = res.resultado;

        }
    })

    this._timeService.ListarTimes().subscribe((res)=>{
      if(res.sucesso){
        this.listaTimes = res.resultado;
        this.isLoading = false;
        this.time_select = this.listaTimes.find((time)=> time.id === this.JogadorEdit.time_id);
        this.setupFormJogador(this.JogadorEdit);

      }
    });

  }



  OnSubmit(){
    let jogador:Jogador = new Jogador();
    this.submitted = true;
    this.isLoading = true;
    jogador.id = this.formulario.controls['id'].value;
    jogador.name = this.formulario.controls['nome'].value;
    jogador.age = this.formulario.controls['idade'].value;
    jogador.time_id = (this.formulario.controls['time'].value).id;

   this._jogadorService.EditarJogador(jogador).subscribe((res)=>{

    if(res.sucesso){
      Swal.fire<boolean>("Sucesso!", "Editado Com sucesso!", 'success');
      this.submitted = false;
      this.isLoading = false;
      this.formulario.reset();
    }else{
      Swal.fire<boolean>("Erro!", "Houve um Erro ao Editar o Jogador!", 'error');
      this.isLoading = false;
      console.log(res);
    }

   });

  }

}
