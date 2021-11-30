import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunosComponent } from './components/alunos/alunos.component';
import { ProfessorComponent } from './components/professor/professor.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { ProfessorDetalheComponent } from './components/professor/professor-detalhe/professor-detalhe.component';


const routes: Routes = [
  { path: 'alunos', component: AlunosComponent },
  { path: 'alunos/:id', component: AlunosComponent },
  { path: 'professores', component: ProfessorComponent },
  { path: 'professor/:id', component: ProfessorDetalheComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
