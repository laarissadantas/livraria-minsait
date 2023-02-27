import { NgModule } from '@angular/core';
import { MaterialModule } from 'src/app/shared/material.module';
import { SharedModule } from './../../shared/shared.module';
import { EditorasRoutingModule } from './editoras-routing.module';
import { AddEditEditoraComponent } from './pages/add-edit-editora/add-edit-editora.component';
import { EditorasComponent } from './pages/editoras.component';
import { ListDeleteEditorasComponent } from './pages/list-delete-editoras/list-delete-editoras.component';

@NgModule({
  declarations: [
    EditorasComponent,
    ListDeleteEditorasComponent,
    AddEditEditoraComponent,
  ],
  imports: [EditorasRoutingModule, MaterialModule, SharedModule],
})
export class EditorasModule {}
