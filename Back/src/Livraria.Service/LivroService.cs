using Livraria.Model;
using Livraria.Repository.Interfaces;
using Livraria.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<Livro> AddLivroAsync(Livro model)
        {
            try
            {
                _livroRepository.Add(model);
                if (await _livroRepository.SaveChangesAsync())
                {
                    return await _livroRepository.GetLivroByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Livro> UpdateLivro(Livro model)
        {
            try
            {
                var livro = await _livroRepository.GetLivroByIdAsync(model.Id);
                if (livro == null) return null;
                
                _livroRepository.RemoveAutoresLivros(livro);
                _livroRepository.Update(model);
                if (await _livroRepository.SaveChangesAsync())
                {
                    return await _livroRepository.GetLivroByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteLivro(int id)
        {
            try
            {
                var livro = await _livroRepository.GetLivroByIdAsync(id);
                if (livro == null) throw new Exception("Livro não encontrado");

                _livroRepository.Delete(livro);

                return await _livroRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Livro>> GetAllLivrosAsync()
        {
            try
            {
                var livros = await _livroRepository.GetAllLivrosAsync();
                if (livros == null) return null;

                return livros;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Livro> GetLivroByIdAsync(int id)
        {
            try
            {
                var livro = await _livroRepository.GetLivroByIdAsync(id);
                if (livro == null) return null;

                return livro;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
