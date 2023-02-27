import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { finalize } from 'rxjs/operators';
import { Editora } from '../../../../core/models/editora';
import { ConfirmDeleteComponent } from '../../../../shared/components/confirm-delete/confirm-delete.component';
import { AddEditEditoraComponent } from '../add-edit-editora/add-edit-editora.component';
import { EditoraService } from './../../../../core/services/editora.service';

@Component({
  selector: 'app-list-delete-editoras',
  templateUrl: './list-delete-editoras.component.html',
  styleUrls: ['./list-delete-editoras.component.scss'],
})
export class ListDeleteEditorasComponent implements OnInit {
  dataSource: Editora[] = [];
  columns = ['nome', 'acoes'];
  isLoading: boolean = false;

  constructor(
    public editoraService: EditoraService,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getEditoras();
  }

  getEditoras() {
    this.isLoading = true;
    this.editoraService
      .getEditoras()
      .pipe(finalize(() => (this.isLoading = false)))
      .subscribe((editoras) => {
        this.dataSource = editoras;
      });
  }

  addEditEditora(editora?: Editora) {
    this.dialog
      .open(AddEditEditoraComponent, {
        width: '350px',
        height: '220px',
        data: {
          editora,
        },
      })
      .afterClosed()
      .subscribe((confirm) => {
        if (confirm) {
          this.getEditoras();
        }
      });
  }

  deleteEditora(id: number) {
    this.dialog
      .open(ConfirmDeleteComponent, {
        width: '300px',
        height: '200px',
        data: {
          id,
        },
      })
      .afterClosed()
      .subscribe((confirm) => {
        if (confirm) {
          this.editoraService.deleteEditora(id).subscribe(() => {
            this.getEditoras();
          });
        }
      });
  }
}
