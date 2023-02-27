using Livraria.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Repository.Interfaces
{
    public interface IEditoraRepository : IGeralRepository
    {
        Task<IEnumerable<Editora>> GetAllEditorasAsync();
        Task<Editora> GetEditoraByIdAsync(int id);
    }
}
