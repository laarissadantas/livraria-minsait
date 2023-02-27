import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Editora } from '../models/editora';

@Injectable({
  providedIn: 'root',
})
export class EditoraService {
  constructor(public http: HttpClient) {}

  getEditoras() {
    return this.http.get<Editora[]>(`${environment.urlApi}/editoras`);
  }

  saveEditora(editora: Editora) {
    return editora.id
      ? this.http.put(`${environment.urlApi}/editoras/${editora.id}`, editora)
      : this.http.post(`${environment.urlApi}/editoras`, editora);
  }

  deleteEditora(id: number) {
    return this.http.delete(`${environment.urlApi}/editoras/${id}`);
  }
}
