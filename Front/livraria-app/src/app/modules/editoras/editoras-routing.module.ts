import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditorasComponent } from './pages/editoras.component';
import { ListDeleteEditorasComponent } from './pages/list-delete-editoras/list-delete-editoras.component';

const routes: Routes = [
  {
    path: '',
    component: EditorasComponent,
    children: [
      {
        path: '',
        component: ListDeleteEditorasComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EditorasRoutingModule {}
