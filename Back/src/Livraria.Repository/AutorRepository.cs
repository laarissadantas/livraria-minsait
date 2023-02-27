using Livraria.Model;
using Livraria.Repository.Contexts;
using Livraria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Repository
{
    public class AutorRepository : GeralRepository, IAutorRepository 
    {
        private readonly LivrariaContext _context;

        public AutorRepository(LivrariaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autor>> GetAllAutoresAsync()
        {
            return await _context.Autores
                .Include(a => a.AutoresLivros)
                .ThenInclude(al => al.Livro)
                .OrderBy(l => l.Nome)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Autor> GetAutorByIdAsync(int id)
        {
            return await _context.Autores
                .Include(a => a.AutoresLivros)
                .ThenInclude(al => al.Livro)
                .Where(l => l.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
