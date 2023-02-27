using Livraria.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Repository.Interfaces
{
    public interface ILivroRepository : IGeralRepository
    {
        Task<IEnumerable<Livro>> GetAllLivrosAsync();
        Task<Livro> GetLivroByIdAsync(int id);
        void RemoveAutoresLivros(Livro livro);
    }
}
