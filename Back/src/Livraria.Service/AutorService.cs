using Livraria.Model;
using Livraria.Repository.Interfaces;
using Livraria.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Service
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<Autor> AddAutor(Autor model)
        {
            try
            {
                _autorRepository.Add(model);
                if (await _autorRepository.SaveChangesAsync())
                {
                    return await _autorRepository.GetAutorByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Autor> UpdateAutor(Autor model)
        {
            try
            {
                var autor = await _autorRepository.GetAutorByIdAsync(model.Id);
                if (autor == null) return null;

                _autorRepository.Update(model);
                if (await _autorRepository.SaveChangesAsync())
                {
                    return await _autorRepository.GetAutorByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteAutor(int id)
        {
            try
            {
                var autor = await _autorRepository.GetAutorByIdAsync(id);
                if (autor == null) throw new Exception("Autor não encontrado");

                _autorRepository.Delete(autor);

                return await _autorRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Autor>> GetAllAutores()
        {
            try
            {
                var autor = await _autorRepository.GetAllAutoresAsync();
                if (autor == null) return null;

                return autor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Autor> GetAutorById(int id)
        {
            try
            {
                var autor = await _autorRepository.GetAutorByIdAsync(id);
                if (autor == null) return null;

                return autor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
