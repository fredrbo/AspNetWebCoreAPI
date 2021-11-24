import { Component, OnInit, OnDestroy, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
// import { PaginatedResult, Pagination } from 'src/app/models/Pagination';

import { Aluno } from '../../models/Aluno';
import { Professor } from '../../models/Professor';

import { AlunoService } from '../../services/aluno.service';
import { ProfessorService } from '../../services/professor.service';
@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit, OnDestroy {

  public titulo = 'Aluno'
  public modalRef: BsModalRef;
  public alunoForm: FormGroup;
  public alunoSelecionado: Aluno;
  public textSimple: string;
  public profsAlunos: Professor[];

  private unsubscriber = new Subject();


  public alunos = [];
  // public alunos = Aluno[];
  public aluno: Aluno;
  public msnDelteAluno: string;
  public modeSave = 'post'

  constructor(
    private alunoService: AlunoService,
    private route: ActivatedRoute,
    private professorService: ProfessorService,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
  ) {
    this.criarForm();

  }

  openModal(template: TemplateRef<any>, alunoId: number) {
    this.professoresAlunos(template, alunoId);
  }

  closeModal() {
    this.modalRef.hide();
  }

  ngOnInit(): void {
    this.carregarAlunos();
  }

  ngOnDestroy(){
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }
  professoresAlunos(template: TemplateRef<any>, id: number){
    this.spinner.show();
    this.professorService.getByAlunoId(id)
    .pipe(takeUntil(this.unsubscriber))
    .subscribe((professores: Professor[]) => {
      this.profsAlunos = professores;
      this.modalRef = this.modalService.show(template);
    }, (error: any) => {
      this.toastr.error(`erro: ${error.message}`);
      console.error(error);
      this.spinner.hide();
     }, () => this.spinner.hide )
  }

  alunoSelect(aluno: Aluno) {
    this.modeSave = 'put';
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno);
  }

  voltar() {
    this.alunoSelecionado = null;
  }

  alunoSubmit() {
    console.log(this.alunoForm.value);
  }
  criarForm() {
    this.alunoForm = this.fb.group({
      id:[0],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required],
    });
  }

  carregarAlunos() {
    const id = +this.route.snapshot.paramMap.get('id');

    this.spinner.show();
    this.alunoService.getAll()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((alunos: Aluno[]) => {
        this.alunos = alunos;

        if (id > 0) {
          this.alunoSelect(this.alunos.find(aluno => aluno.id === id));
        }

        this.toastr.success('Alunos foram carregado com Sucesso!');
      }, (error: any) => {
        this.toastr.error('Alunos não carregados!');
        console.error(error);
        this.spinner.hide();
      }, () => this.spinner.hide()
    );
  }
  saveAluno() {
    if (this.alunoForm.valid) {
      this.spinner.show();

      if (this.modeSave === 'post') {
        this.aluno = {...this.alunoForm.value};
      } else {
        this.aluno = {id: this.alunoSelecionado.id, ...this.alunoForm.value};
      }

      this.alunoService[this.modeSave](this.aluno)
        .pipe(takeUntil(this.unsubscriber))
        .subscribe(
          () => {
            this.carregarAlunos();
            this.toastr.success('Aluno salvo com sucesso!');
          }, (error: any) => {
            this.toastr.error(`Erro: Aluno não pode ser salvo!`);
            console.error(error);
            this.spinner.hide();
          }, () => this.spinner.hide()
        );

    }
  }
  
}
