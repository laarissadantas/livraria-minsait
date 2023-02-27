import { NgModule } from '@angular/core';
import { MaterialModule } from 'src/app/shared/material.module';
import { SharedModule } from './../../shared/shared.module';
import { LivrosRoutingModule } from './livros-routing.module';
import { AddEditLivroComponent } from './pages/add-edit-livro/add-edit-livro.component';
import { ListDeleteLivrosComponent } from './pages/list-delete-livros/list-delete-livros.component';
import { LivrosComponent } from './pages/livros.component';

@NgModule({
  declarations: [
    LivrosComponent,
    ListDeleteLivrosComponent,
    AddEditLivroComponent,
  ],
  imports: [LivrosRoutingModule, MaterialModule, SharedModule],
})
export class LivrosModule {}
