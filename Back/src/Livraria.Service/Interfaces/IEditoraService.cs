using Livraria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Service.Interfaces
{
    public interface IEditoraService
    {
        Task<Editora> AddEditora(Editora model);
        Task<Editora> UpdateEditora(Editora model);
        Task<bool> DeleteEditora(int id);
        Task<Editora> GetEditoraById(int id);
        Task<IEnumerable<Editora>> GetAllEditoras();
    }
}
