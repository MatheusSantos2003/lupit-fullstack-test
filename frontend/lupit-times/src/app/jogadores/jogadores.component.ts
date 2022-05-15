import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { JogadoresService } from './../shared/services/jogadores.service';
import { Component, OnInit } from '@angular/core';
import Jogador from '../shared/models/Jogador.model';


@Component({
  selector: 'app-jogadores',
  templateUrl: './jogadores.component.html',
  styleUrls: ['./jogadores.component.css']
})
export class JogadoresComponent implements OnInit {

  ListaJogadores: Jogador[] = [];
  isLoading: boolean = false;

  constructor(private _jogadoresService: JogadoresService, private router:Router) { }

  ngOnInit(): void {
    this.isLoading = true;
    this.obterJogadores();
  }

  Editar(id:number) {
    this.router.navigateByUrl(`/jogador/${id}`);
  }

  async Excluir(id: number) {

    let confirmar = (await Swal.fire({
      title: "Tem certeza?", showDenyButton: true, html: "Remover o jogador é uma ação irreversível",
      customClass: {
        confirmButton: 'order-2',
        denyButton: 'order-1',
      },
      confirmButtonText: 'Sim',
      denyButtonText: 'Não',
    })).isConfirmed;

    if (confirmar) {
      this.isLoading = true;
      this._jogadoresService.RemoverJogador(id).subscribe((res) => {
        if (res.sucesso) {
          Swal.fire("Sucesso!", "Jogador Removido com Sucesso!", 'success');
          this.obterJogadores();
          this.isLoading = false;
        } else {
          Swal.fire<boolean>("Erro!", "Houve um Erro ao Cadastrar um time!", 'error');
        }
      })
    }

  }

  obterJogadores() {
    this._jogadoresService.ListarJogadores().subscribe((res) => {
      if (res.sucesso) {
        this.ListaJogadores = res.resultado;
        this.isLoading = false;
      }
    });
  }

}
