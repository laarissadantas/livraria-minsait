import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Livro } from '../../../../core/models/livro';
import { LivroService } from '../../../../core/services/livro.service';
import { Autor } from './../../../../core/models/autor';
import { Editora } from './../../../../core/models/editora';
import { AutoresLivros } from './../../../../core/models/livro';
import { AutorService } from './../../../../core/services/autor.service';
import { EditoraService } from './../../../../core/services/editora.service';

@Component({
  selector: 'app-add-edit-livro',
  templateUrl: './add-edit-livro.component.html',
  styleUrls: ['./add-edit-livro.component.scss'],
})
export class AddEditLivroComponent implements OnInit {
  livro: Livro;
  form: FormGroup = new FormGroup({});

  autores: Autor[] = [];
  editoras: Editora[] = [];

  constructor(
    public dialogRef: MatDialogRef<AddEditLivroComponent>,
    @Inject(MAT_DIALOG_DATA) dialogData: any,
    public formBuilder: FormBuilder,
    public autorService: AutorService,
    public editoraService: EditoraService,
    public livroService: LivroService
  ) {
    this.livro = dialogData.livro;
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [this.livro?.id],
      titulo: [this.livro?.titulo ?? '', Validators.required],
      subtitulo: [this.livro?.subtitulo ?? ''],
      resumo: [this.livro?.resumo ?? ''],
      qtdPaginas: [
        this.livro?.qtdPaginas ?? '',
        [Validators.required, Validators.min(1), Validators.max(10000)],
      ],
      dataPublicacao: [this.livro?.dataPublicacao ?? '', Validators.required],
      editoraId: [this.livro?.editora?.id ?? '', Validators.required],
      edicao: [
        this.livro?.edicao ?? '',
        [Validators.min(1), Validators.max(20)],
      ],
      autoresId: [
        this.livro?.autoresLivros?.map((autorLivro) => autorLivro.autorId) ??
          '',
        Validators.required,
      ],
    });
    this.form.get('autores')?.valueChanges.subscribe(console.log);
    this.getAutores();
    this.getEditoras();
  }

  getAutores() {
    this.autorService.getAutores().subscribe((autores) => {
      this.autores = autores;
    });
  }

  getEditoras() {
    this.editoraService.getEditoras().subscribe((editoras) => {
      this.editoras = editoras;
    });
  }

  saveLivro() {
    if (this.form.valid) {
      const livro: Livro = this.form.getRawValue();
      if (!livro.id) {
        delete livro.id;
      }
      livro.dataPublicacao = new Date(livro.dataPublicacao).toISOString();
      if (livro.autoresId) {
        livro.autoresLivros = livro.autoresId.map(
          (id: number) => ({ autorId: id } as AutoresLivros)
        );
        delete livro.autores;
      }
      this.livroService.saveLivro(livro).subscribe(() => {
        this.dialogRef.close(true);
      });
    }
  }
}
