import { ValidatorField } from './../../../helpers/ValidatorField';
import { FormGroup, FormBuilder, Validators, AbstractControlOptions } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  public titulo = 'Perfil'

  form: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.validation();
  }

  public validation(): any {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMach('senha', 'confirmaSenha')
    };

    this.form = this.formBuilder.group({
      titulo: ['', Validators.required],
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['', Validators.required],
      telefone: ['', Validators.required],
      funcao: ['', Validators.required],
      descricao: ['', Validators.required],
      senha: ['', Validators.required],
      confirmaSenha: ['', Validators.required]
    }, formOptions)
  }


}
