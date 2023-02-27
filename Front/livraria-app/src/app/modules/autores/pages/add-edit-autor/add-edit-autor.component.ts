import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Autor } from './../../../../core/models/autor';
import { AutorService } from './../../../../core/services/autor.service';

@Component({
  selector: 'app-add-edit-autor',
  templateUrl: './add-edit-autor.component.html',
  styleUrls: ['./add-edit-autor.component.scss'],
})
export class AddEditAutorComponent implements OnInit {
  autor: Autor;
  form: FormGroup = new FormGroup({});

  constructor(
    public dialogRef: MatDialogRef<AddEditAutorComponent>,
    @Inject(MAT_DIALOG_DATA) dialogData: any,
    public formBuilder: FormBuilder,
    public autorService: AutorService
  ) {
    this.autor = dialogData.autor;
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [this.autor?.id],
      nome: [this.autor?.nome ?? '', Validators.required],
    });
  }

  verifySameNome() {
    return (
      this.autor && this.autor.nome === this.form.get('nome')?.value.trim()
    );
  }

  saveAutor() {
    if (this.form.valid) {
      const autor: Autor = this.form.getRawValue();
      if (!autor.id) {
        delete autor.id;
      }
      this.autorService.saveAutor(autor).subscribe(() => {
        this.dialogRef.close(true);
      });
    }
  }
}
