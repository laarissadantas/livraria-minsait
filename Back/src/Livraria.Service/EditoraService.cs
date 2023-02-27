using Livraria.Model;
using Livraria.Repository.Interfaces;
using Livraria.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Service
{
    public class EditoraService : IEditoraService
    {
        private readonly IEditoraRepository _editoraRepository;

        public EditoraService(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public async Task<Editora> AddEditora(Editora model)
        {
            try
            {
                _editoraRepository.Add(model);
                if (await _editoraRepository.SaveChangesAsync())
                {
                    return await _editoraRepository.GetEditoraByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Editora> UpdateEditora(Editora model)
        {
            try
            {
                var editora = await _editoraRepository.GetEditoraByIdAsync(model.Id);
                if (editora == null) return null;

                _editoraRepository.Update(model);
                if (await _editoraRepository.SaveChangesAsync())
                {
                    return await _editoraRepository.GetEditoraByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEditora(int id)
        {
            try
            {
                var editora = await _editoraRepository.GetEditoraByIdAsync(id);
                if (editora == null) throw new Exception("Editora não encontrada");

                _editoraRepository.Delete(editora);

                return await _editoraRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Editora>> GetAllEditoras()
        {
            try
            {
                var editoras = await _editoraRepository.GetAllEditorasAsync();
                if (editoras == null) return null;

                return editoras;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Editora> GetEditoraById(int id)
        {
            try
            {
                var editora = await _editoraRepository.GetEditoraByIdAsync(id);
                if (editora == null) return null;

                return editora;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
