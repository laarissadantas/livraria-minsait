using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Repository.Interfaces
{
    public interface IGeralRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
