using Microsoft.AspNetCore.Mvc;
using Livraria.Service.Interfaces;
using Livraria.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace Livraria.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutoresController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var autors = await _autorService.GetAllAutores();
                if (autors == null) return NotFound("Nenhuma autor encontrado");

                return Ok(autors);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar autores. Erro: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var autor = await _autorService.GetAutorById(id);
                if (autor == null) return NotFound("Autor não encontrado");

                return Ok(autor);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar autores. Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Autor model)
        {
            try
            {
                var autor = await _autorService.AddAutor(model);
                if (autor == null) return BadRequest("Erro ao tentar adicionar autor");

                return Ok(autor);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar autor. Erro: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Autor model)
        {
            try
            {
                var autor = await _autorService.UpdateAutor(model);
                if (autor == null) return BadRequest("Erro ao tentar alterar autor");

                return Ok(autor);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar autores. Erro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _autorService.DeleteAutor(id))
                {
                    return Ok();
                } else
                {
                    return BadRequest("Erro ao tentar deletar autor");
                }

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar autor. Erro: {e.Message}");
            }
        }

    }
}
