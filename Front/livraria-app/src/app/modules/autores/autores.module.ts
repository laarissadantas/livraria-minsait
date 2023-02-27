import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MaterialModule } from 'src/app/shared/material.module';
import { SharedModule } from './../../shared/shared.module';
import { AutoresRoutingModule } from './autores-routing.module';
import { AddEditAutorComponent } from './pages/add-edit-autor/add-edit-autor.component';
import { AutoresComponent } from './pages/autores.component';
import { ListDeleteAutoresComponent } from './pages/list-delete-autores/list-delete-autores.component';

@NgModule({
  declarations: [
    AutoresComponent,
    ListDeleteAutoresComponent,
    AddEditAutorComponent,
  ],
  imports: [AutoresRoutingModule, MaterialModule, SharedModule],
})
export class AutoresModule {}
