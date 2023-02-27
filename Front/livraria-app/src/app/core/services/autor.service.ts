import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../../environments/environment';
import { Autor } from './../models/autor';

@Injectable({
  providedIn: 'root',
})
export class AutorService {
  constructor(public http: HttpClient) {}

  getAutores() {
    return this.http.get<Autor[]>(`${environment.urlApi}/autores`);
  }

  saveAutor(autor: Autor) {
    return autor.id
      ? this.http.put(`${environment.urlApi}/autores/${autor.id}`, autor)
      : this.http.post(`${environment.urlApi}/autores`, autor);
  }

  deleteAutor(id: number) {
    return this.http.delete(`${environment.urlApi}/autores/${id}`);
  }
}
