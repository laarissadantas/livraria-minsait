using Livraria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Service.Interfaces
{
    public interface ILivroService
    {
        Task<Livro> AddLivroAsync(Livro model);
        Task<Livro> UpdateLivro(Livro model);
        Task<bool> DeleteLivro(int id);
        Task<Livro> GetLivroByIdAsync(int id);
        Task<IEnumerable<Livro>> GetAllLivrosAsync();
    }
}
