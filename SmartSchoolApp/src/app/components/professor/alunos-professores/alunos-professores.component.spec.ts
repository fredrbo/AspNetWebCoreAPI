import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlunosProfessoresComponent } from './alunos-professores.component';

describe('AlunosProfessoresComponent', () => {
  let component: AlunosProfessoresComponent;
  let fixture: ComponentFixture<AlunosProfessoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlunosProfessoresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AlunosProfessoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
