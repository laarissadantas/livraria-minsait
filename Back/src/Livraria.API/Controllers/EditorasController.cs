using Microsoft.AspNetCore.Mvc;
using Livraria.Service.Interfaces;
using Livraria.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace Livraria.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditorasController : ControllerBase
    {
        private readonly IEditoraService _editoraService;

        public EditorasController(IEditoraService editoraService)
        {
            _editoraService = editoraService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var editoras = await _editoraService.GetAllEditoras();
                if (editoras == null) return NotFound("Nenhuma editora encontrada");

                return Ok(editoras);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar editoras. Erro: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var editora = await _editoraService.GetEditoraById(id);
                if (editora == null) return NotFound("Editora não encontrada");

                return Ok(editora);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar editoras. Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Editora model)
        {
            try
            {
                var editora = await _editoraService.AddEditora(model);
                if (editora == null) return BadRequest("Erro ao tentar adicionar editora");

                return Ok(editora);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar editora. Erro: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Editora model)
        {
            try
            {
                var editora = await _editoraService.UpdateEditora(model);
                if (editora == null) return BadRequest("Erro ao tentar alterar editora");

                return Ok(editora);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar editoras. Erro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _editoraService.DeleteEditora(id))
                {
                    return Ok();
                } else
                {
                    return BadRequest("Erro ao tentar deletar editora");
                }

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar editora. Erro: {e.Message}");
            }
        }

    }
}
