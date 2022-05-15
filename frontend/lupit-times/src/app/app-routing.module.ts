import { EditarJogadorComponent } from './editar-jogador/editar-jogador.component';
import { TimesComponent } from './times/times.component';
import { CadastroJogadorComponent } from './cadastro-jogador/cadastro-jogador.component';
import { JogadoresComponent } from './jogadores/jogadores.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroTimeComponent } from './cadastro-time/cadastro-time.component';

const routes: Routes = [
  {
    path:"",
    redirectTo:"jogador",
    pathMatch:'full'
  },
  {
    path:"jogador",
    children:
    [
      {
        path:"",
        component:JogadoresComponent
      },
      {
      path:"novo",
      component:CadastroJogadorComponent
      },
      {
        path:":id",
        component: EditarJogadorComponent
      }
  ]
  },
  {
    path:"*",
    pathMatch:"full",
    component:JogadoresComponent
  },
  {
    path:"Times",
    component: TimesComponent
  },
  {
    path:"CadastrarTime",
    component: CadastroTimeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
