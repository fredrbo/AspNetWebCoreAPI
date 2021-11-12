import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Aluno } from 'src/app/models/Aluno';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {

  public modalRef: BsModalRef;
  public alunoForm: FormGroup;
  public alunoSelecionado: Aluno;
  public textSimple: string;

  public alunos = [
    { id: 1,nome: 'Marta', sobrenome: 'Kent', telefone: 332255 },
    { id: 2,nome: 'Paula', sobrenome: 'Isabela', telefone: 1234324 },
    { id: 3,nome: 'Laura', sobrenome: 'Antonia', telefone: 78978675 },
    { id: 4,nome: 'Luiza', sobrenome: 'Maria', telefone: 2301784213 },
    { id: 5,nome: 'Lucas', sobrenome: 'Machado', telefone: 234523465 },
    { id: 6,nome: 'Pedro', sobrenome: 'Alvares', telefone: 54616465411 },
    { id: 7,nome: 'Paulo', sobrenome: 'José', telefone: 15645613 },
  ];
  
  constructor(private modalService: BsModalService,
              private fb: FormBuilder) {
    this.criarForm();
  }
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }


  ngOnInit(): void {

  }

  alunoSelect(aluno: Aluno){
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno);
  }

  voltar(){
    this.alunoSelecionado = null;
  }

  alunoSubmit(){
    console.log(this.alunoForm.value);
  }
  criarForm(){
    this.alunoForm = this.fb.group({
      nome: ['', Validators.required],
      sobrenome: ['',  Validators.required],
      telefone: ['',  Validators.required],
    });
  }
}
