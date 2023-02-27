using Livraria.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Repository.Interfaces
{
    public interface IAutorRepository : IGeralRepository
    {
        Task<IEnumerable<Autor>> GetAllAutoresAsync();
        Task<Autor> GetAutorByIdAsync(int id);
    }
}
