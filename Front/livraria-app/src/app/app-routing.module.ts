import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'livros',
    loadChildren: () =>
      import('./modules/livros/livros.module').then((m) => m.LivrosModule),
  },
  {
    path: 'autores',
    loadChildren: () =>
      import('./modules/autores/autores.module').then((m) => m.AutoresModule),
  },
  {
    path: 'editoras',
    loadChildren: () =>
      import('./modules/editoras/editoras.module').then(
        (m) => m.EditorasModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
