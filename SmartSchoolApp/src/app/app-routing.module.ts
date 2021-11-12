import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProfessorComponent } from './components/professor/professor.component';
import { AlunosComponent } from './components/alunos/alunos.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PerfilComponent } from './components/perfil/perfil.component';

const routes: Routes = [
  {path: 'alunos',component: AlunosComponent},
  {path: 'professores',component: ProfessorComponent},
  {path: 'perfil',component: PerfilComponent},
  {path: 'dashboard',component: DashboardComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
