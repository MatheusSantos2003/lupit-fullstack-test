import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule} from "@angular/common/http";
import { AppComponent } from './app.component';
import { JogadoresComponent } from './jogadores/jogadores.component';
import { CadastroJogadorComponent } from './cadastro-jogador/cadastro-jogador.component'
import { EditarJogadorComponent } from './editar-jogador/editar-jogador.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { CadastroTimeComponent } from './cadastro-time/cadastro-time.component';
import { TimesComponent } from './times/times.component';
import { PreloaderComponent } from './shared/components/preloader/preloader.component';

@NgModule({
  declarations: [
    AppComponent,
    JogadoresComponent,
    CadastroJogadorComponent,
    EditarJogadorComponent,
    HeaderComponent,
    CadastroTimeComponent,
    TimesComponent,
    PreloaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
