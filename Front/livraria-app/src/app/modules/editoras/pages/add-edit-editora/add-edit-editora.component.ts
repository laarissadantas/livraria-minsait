import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Editora } from '../../../../core/models/editora';
import { EditoraService } from '../../../../core/services/editora.service';

@Component({
  selector: 'app-add-edit-editora',
  templateUrl: './add-edit-editora.component.html',
  styleUrls: ['./add-edit-editora.component.scss'],
})
export class AddEditEditoraComponent implements OnInit {
  editora: Editora;
  form: FormGroup = new FormGroup({});

  constructor(
    public dialogRef: MatDialogRef<AddEditEditoraComponent>,
    @Inject(MAT_DIALOG_DATA) dialogData: any,
    public formBuilder: FormBuilder,
    public editoraService: EditoraService
  ) {
    this.editora = dialogData.editora;
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [this.editora?.id],
      nome: [this.editora?.nome ?? '', Validators.required],
    });
  }

  verifySameNome() {
    return (
      this.editora && this.editora.nome === this.form.get('nome')?.value.trim()
    );
  }

  saveEditora() {
    if (this.form.valid) {
      const editora: Editora = this.form.getRawValue();
      if (!editora.id) {
        delete editora.id;
      }
      this.editoraService.saveEditora(editora).subscribe(() => {
        this.dialogRef.close(true);
      });
    }
  }
}
