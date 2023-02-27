import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { finalize } from 'rxjs/operators';
import { Autor } from './../../../../core/models/autor';
import { AutorService } from './../../../../core/services/autor.service';
import { ConfirmDeleteComponent } from './../../../../shared/components/confirm-delete/confirm-delete.component';
import { AddEditAutorComponent } from './../add-edit-autor/add-edit-autor.component';

@Component({
  selector: 'app-list-delete-autores',
  templateUrl: './list-delete-autores.component.html',
  styleUrls: ['./list-delete-autores.component.scss'],
})
export class ListDeleteAutoresComponent implements OnInit {
  dataSource: Autor[] = [];
  columns = ['nome', 'acoes'];
  isLoading: boolean = false;

  constructor(public autorService: AutorService, public dialog: MatDialog) {}

  ngOnInit() {
    this.getAutores();
  }

  getAutores() {
    this.isLoading = true;
    this.autorService
      .getAutores()
      .pipe(finalize(() => (this.isLoading = false)))
      .subscribe((autores) => {
        this.dataSource = autores;
      });
  }

  addEditAutor(autor?: Autor) {
    this.dialog
      .open(AddEditAutorComponent, {
        width: '350px',
        height: '220px',
        data: {
          autor,
        },
      })
      .afterClosed()
      .subscribe((confirm) => {
        if (confirm) {
          this.getAutores();
        }
      });
  }

  deleteAutor(id: number) {
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
          this.autorService.deleteAutor(id).subscribe(() => {
            this.getAutores();
          });
        }
      });
  }
}
