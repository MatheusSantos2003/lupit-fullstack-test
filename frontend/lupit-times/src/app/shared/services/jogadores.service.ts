import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';
import Time from '../models/Time.model';
import ResponseModel from '../models/ResponseModel';
import Jogador from '../models/Jogador.model';

@Injectable({
  providedIn: 'root'
})
export class JogadoresService {

  constructor(private http: HttpClient) { }

  private apiUrl = "http://localhost:2797/api";


  public ListarJogadores() {
    return this.http.get<ResponseModel<Jogador[]>>(`${this.apiUrl}/Jogadores/ListarJogadores`)
      .pipe(
        map((response) => {
          return response;
        })
      );
  }

  public CadastrarJogador(jogador:Jogador) {
    return this.http.post<ResponseModel<any>>(`${this.apiUrl}/Jogadores/AdicionarJogador`,jogador)
    .pipe(
      map((response)=>{
        return response;
      })
    )
  }

  public EditarJogador(jogador:Jogador){
    console.log(jogador);
    return this.http.put<ResponseModel<any>>(`${this.apiUrl}/Jogadores/EditarJogador/${jogador.id}`,jogador)
    .pipe(
      map((response)=>{
        return response;
      })
    )
  }

  public RemoverJogador(id:number){
    return this.http.delete<ResponseModel<boolean>>(`${this.apiUrl}/Jogadores/ExcluirJogador/${id}`)
    .pipe(
      map((response)=>{
        return response;
      })
    )
  }

  public BuscarJogador(id:number){
    return this.http.get<ResponseModel<Jogador>>(`${this.apiUrl}/Jogadores/BuscarJogador/${id}`)
    .pipe(
      map((response)=>{
        return response;
      })
    )
  }


}
