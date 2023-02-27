using Livraria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Service.Interfaces
{
    public interface IAutorService
    {
        Task<Autor> AddAutor(Autor model);
        Task<Autor> UpdateAutor(Autor model);
        Task<bool> DeleteAutor(int id);
        Task<Autor> GetAutorById(int id);
        Task<IEnumerable<Autor>> GetAllAutores();
    }
}
