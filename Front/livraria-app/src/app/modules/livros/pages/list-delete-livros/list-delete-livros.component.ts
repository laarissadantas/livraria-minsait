import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { finalize } from 'rxjs/operators';
import { Livro } from '../../../../core/models/livro';
import { LivroService } from '../../../../core/services/livro.service';
import { ConfirmDeleteComponent } from '../../../../shared/components/confirm-delete/confirm-delete.component';
import { AddEditLivroComponent } from '../add-edit-livro/add-edit-livro.component';

@Component({
  selector: 'app-list-delete-livros',
  templateUrl: './list-delete-livros.component.html',
  styleUrls: ['./list-delete-livros.component.scss'],
})
export class ListDeleteLivrosComponent implements OnInit {
  dataSource: Livro[] = [];
  columns = [
    'titulo',
    'subtitulo',
    'resumo',
    'qtdPaginas',
    'dataPublicacao',
    'editora',
    'edicao',
    'autor',
    'acoes',
  ];
  isLoading: boolean = false;

  constructor(public livroService: LivroService, public dialog: MatDialog) {}

  ngOnInit() {
    this.getLivros();
  }

  getLivros() {
    this.isLoading = true;
    this.livroService
      .getLivros()
      .pipe(finalize(() => (this.isLoading = false)))
      .subscribe((livros) => {
        this.dataSource = livros;
      });
  }

  addEditLivro(livro?: Livro) {
    this.dialog
      .open(AddEditLivroComponent, {
        width: '600px',
        height: '600px',
        data: {
          livro,
        },
      })
      .afterClosed()
      .subscribe((confirm) => {
        if (confirm) {
          this.getLivros();
        }
      });
  }

  deleteLivro(id: number) {
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
          this.livroService.deleteLivro(id).subscribe(() => {
            this.getLivros();
          });
        }
      });
  }
}
