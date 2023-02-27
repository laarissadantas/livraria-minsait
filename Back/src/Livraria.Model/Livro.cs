using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Model
{
    public class Livro
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Titulo { get; set; }
        [StringLength(100)]
        public string? Subtitulo { get; set; }
        [StringLength(500)]
        public string? Resumo { get; set; }
        [Range(1, 10000)]
        public int QtdPaginas { get; set; }
        public DateTime DataPublicacao { get; set; }
        [Range(0, 20)]
        public int? Edicao { get; set; }
        public Editora? Editora { get; set; }
        public int? EditoraId { get; set; }
        public IEnumerable<AutorLivro> AutoresLivros { get; set; }
    }
}
