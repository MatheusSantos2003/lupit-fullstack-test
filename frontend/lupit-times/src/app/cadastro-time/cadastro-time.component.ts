import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Time from '../shared/models/Time.model';
import { TimesService } from '../shared/services/times.service';
import Swal from 'sweetalert2';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-cadastro-time',
  templateUrl: './cadastro-time.component.html',
  styleUrls: ['./cadastro-time.component.css']
})
export class CadastroTimeComponent implements OnInit {

  public formulario: FormGroup;
  public submitted: boolean = false;
  public isloading: boolean = false;

  constructor(private formBuild: FormBuilder, private timeService: TimesService,
    private router: Router) {
    this.formulario = this.formBuild.group({
      nome: ['', Validators.required]
    })

  }

  ngOnInit(): void {

  }



  OnSubmit() {
    let time: Time = new Time();
    this.submitted = true;

    time.name = this.formulario.controls['nome'].value

    if (this.formulario.valid) {
      this.timeService.CadastrarTime(time).subscribe((res) => {
        if (res.sucesso) {
          Swal.fire<boolean>("Sucesso!", "Cadastrado Com sucesso!", 'success');

          this.submitted = false;
          this.isloading = false;
          this.formulario.reset();
        } else {
          Swal.fire<boolean>("Erro!", "Houve um Erro ao Cadastrar um time!", 'error');

        }
      })
    }

  }
}
