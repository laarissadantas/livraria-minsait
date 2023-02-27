using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Model
{
    public class Autor
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        public IEnumerable<AutorLivro>? AutoresLivros { get; set; }
    }
}
