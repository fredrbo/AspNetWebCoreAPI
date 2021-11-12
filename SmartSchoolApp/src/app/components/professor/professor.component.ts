import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Professor } from 'src/app/models/Professor';

@Component({
  selector: 'app-professor',
  templateUrl: './professor.component.html',
  styleUrls: ['./professor.component.css']
})
export class ProfessorComponent implements OnInit {

  public profSelecionado: Professor;
  public  modalRef: BsModalRef;

  public professores = [
    { id: 1, nome: 'Lauro', disciplina: 'Matemática' },
    { id: 2, nome: 'Roberto', disciplina: 'Física' },
    { id: 3, nome: "Ronaldo", disciplina: 'Português' },
    { id: 4, nome: "Rodrigo", disciplina: 'Inglês' },
    { id: 5, nome: "Alexandre", disciplina: 'Programação' },
  ]
  constructor(private modalService: BsModalService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  profSelect(professor: Professor) {
    this.profSelecionado = professor;

  }

  voltar() {
    this.profSelecionado = null;
  }

  ngOnInit(): void {
  }

}
