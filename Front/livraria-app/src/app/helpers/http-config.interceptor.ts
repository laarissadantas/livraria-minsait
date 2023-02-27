import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { LoaderService } from './../core/services/loader.service';
import { ErrorComponent } from './error/error.component';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
  constructor(public dialog: MatDialog, public loaderService: LoaderService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    this.loaderService.show();
    return next.handle(request).pipe(
      finalize(() => this.loaderService.hide()),
      catchError((error) => {
        this.dialog.open(ErrorComponent, {
          height: '300px',
          width: '500px',
          data: {
            error,
          },
        });
        return throwError(error);
      })
    );
  }
}
