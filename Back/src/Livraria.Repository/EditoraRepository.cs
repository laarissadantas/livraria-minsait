using Livraria.Model;
using Livraria.Repository.Contexts;
using Livraria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Repository
{
    public class EditoraRepository : GeralRepository, IEditoraRepository
    {
        private readonly LivrariaContext _context;

        public EditoraRepository(LivrariaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Editora>> GetAllEditorasAsync()
        {
            return await _context.Editoras.OrderBy(e => e.Nome).AsNoTracking().ToListAsync();
        }

        public async Task<Editora> GetEditoraByIdAsync(int id)
        {
            return await _context.Editoras.Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
