import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListDeleteLivrosComponent } from './pages/list-delete-livros/list-delete-livros.component';
import { LivrosComponent } from './pages/livros.component';

const routes: Routes = [
  {
    path: '',
    component: LivrosComponent,
    children: [
      {
        path: '',
        component: ListDeleteLivrosComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LivrosRoutingModule {}
