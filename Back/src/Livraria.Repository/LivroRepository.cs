using Livraria.Model;
using Livraria.Repository.Contexts;
using Livraria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Repository
{
    public class LivroRepository : GeralRepository, ILivroRepository
    {
        private readonly LivrariaContext _context;

        public LivroRepository(LivrariaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livro>> GetAllLivrosAsync()
        {
            return await _context.Livros
                .Include(l => l.Editora)
                .Include(l => l.AutoresLivros)
                .ThenInclude(al => al.Autor)
                .OrderBy(l => l.DataPublicacao)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Livro> GetLivroByIdAsync(int id)
        {
            return await _context.Livros
                .Include(l => l.Editora)
                .Include(l => l.AutoresLivros)
                .ThenInclude(al => al.Autor)
                .Where(l => l.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
