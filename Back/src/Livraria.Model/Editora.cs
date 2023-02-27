using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Model
{
    public class Editora
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Nome { get; set; }
        public IEnumerable<Livro>? Livros { get; set; }
    }
}
