using FilmesAPI.models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController] // declara que a classe é um controlador
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List <Filme> filmes = new List<Filme>();

        /// <summary>
        /// Adiciona um filme na lista de filmes.
        /// </summary>
        /// <param name="filme">Passa como um parâmetro um filme</param>

        [HttpPost] // Cria um recurso novo no sistema
        public void AdicionarFilme([FromBody]Filme filme)
        {
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }
    }
}
