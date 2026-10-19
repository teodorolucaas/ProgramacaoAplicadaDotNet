using ApiLivros.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLivros.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        private readonly LivroService _livroService;

        public LivrosController(LivroService livroService)
        {
            _livroService = livroService;
        }

        // V1: GET /api/livros
        [HttpGet]
        public IActionResult Listar()
        {
            var livros = _livroService.Listar();

              return Ok(livros.Select(livro => new
              {
                  livro.Id,
                  livro.Titulo,
                  livro.Autor
              }));

            //return Ok();
        }

        // V2: GET /api/v2/livros
        // Inclui o ano de publicacao na resposta.
        // Adicionar um campo geralmente e compativel e nao exige
        // uma nova versao. Aqui, a V2 serve para demonstrar as rotas.
        [HttpGet("/api/v2/livros")]
        public IActionResult ListarV2()
        {
            var livros = _livroService.Listar();

            return Ok(livros.Select(livro => new
            {
                livro.Id,
                livro.Titulo,
                livro.Autor,
               // livro.AnoPublicacao
            }));
        }
    }
}
