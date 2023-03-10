import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss'],
})
export class ErrorComponent {
  error: HttpErrorResponse;

  constructor(@Inject(MAT_DIALOG_DATA) dialogData: any) {
    this.error = dialogData.error;
  }
}
