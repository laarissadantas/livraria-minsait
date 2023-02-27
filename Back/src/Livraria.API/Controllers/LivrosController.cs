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
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var livros = await _livroService.GetAllLivrosAsync();
                if (livros == null) return NotFound("Nenhum livro encontrado");

                return Ok(livros);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var livro = await _livroService.GetLivroByIdAsync(id);
                if (livro == null) return NotFound("Livro não encontrado");

                return Ok(livro);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Livro model)
        {
            try
            {
                var livro = await _livroService.AddLivroAsync(model);
                if (livro == null) return BadRequest("Erro ao tentar adicionar livro");

                return Ok(livro);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar livro. Erro: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Livro model)
        {
            try
            {
                var livro = await _livroService.UpdateLivro(model);
                if (livro == null) return BadRequest("Erro ao tentar alterar livro");

                return Ok(livro);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _livroService.DeleteLivro(id))
                {
                    return Ok();
                } else
                {
                    return BadRequest("Erro ao tentar deletar livro");
                }

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }

    }
}
