import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutoresComponent } from './pages/autores.component';
import { ListDeleteAutoresComponent } from './pages/list-delete-autores/list-delete-autores.component';

const routes: Routes = [
  {
    path: '',
    component: AutoresComponent,
    children: [
      {
        path: '',
        component: ListDeleteAutoresComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AutoresRoutingModule {}
