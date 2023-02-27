using Livraria.Repository.Contexts;
using Livraria.Repository.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Repository
{
    public class GeralRepository : IGeralRepository
    {
        private readonly LivrariaContext _context;

        public GeralRepository(LivrariaContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
