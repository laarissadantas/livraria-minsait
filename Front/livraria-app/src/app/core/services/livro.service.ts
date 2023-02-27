import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Livro } from '../models/livro';

@Injectable({
  providedIn: 'root',
})
export class LivroService {
  constructor(public http: HttpClient) {}

  getLivros() {
    return this.http.get<Livro[]>(`${environment.urlApi}/livros`);
  }

  saveLivro(livro: Livro) {
    return livro.id
      ? this.http.put(`${environment.urlApi}/livros/${livro.id}`, livro)
      : this.http.post(`${environment.urlApi}/livros`, livro);
  }

  deleteLivro(id: number) {
    return this.http.delete(`${environment.urlApi}/livros/${id}`);
  }
}
