import { Autor } from './autor';
import { Editora } from './editora';

export interface Livro {
  id?: number;
  titulo: string;
  subtitulo?: string;
  resumo?: string;
  qtdPaginas: number;
  dataPublicacao: string;
  editora?: Editora;
  editoraId?: number;
  edicao?: number;
  autores?: Autor[];
  autoresId?: number[];
  autoresLivros?: AutoresLivros[];
}

export interface AutoresLivros {
  autorId: number;
}
