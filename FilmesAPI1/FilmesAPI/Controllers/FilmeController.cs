using FilmesAPI.data;
using FilmesAPI.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilmesAPI.Controllers
{
    [ApiController] // declara que a classe é um controlador
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        public FilmeController(FilmeContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método responsável por cadastrar um filme
        /// </summary>
        /// <param name="filme">Passa um objeto do tipo Filme como parâmetro</param>
        /// <returns>Retorna se o filme foi cadastrado</returns>

        [HttpPost] // Cria um recurso novo no sistema
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmesPorID), new { Id = filme.Id }, filme);
            
        }
        /// <summary>
        /// Lista todos os filmes já cadastrados
        /// </summary>
        /// <returns>Retorna os filmes cadastrados no sistema</returns>
        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes;
        }
        /// <summary>
        /// Lista o filme de acordo com o ID
        /// </summary>
        /// <param name="id">Passa o id do filme que deseja que seja listado</param>
        /// <returns>retorna o filme que possui o ID informado, caso não exista esse filme, retorna o erro 404</returns>
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorID(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
        /// <summary>
        /// Atualiza os valores de um objeto do tipo filme
        /// </summary>
        /// <param name="id">id do filme que será atualizado</param>
        /// <param name="filmenovo">valores que serão atualizados no filme</param>
        /// <returns>retorna o status de no content</returns>

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] Filme filmenovo)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            filme.Titulo = filmenovo.Titulo;
            filme.Genero = filmenovo.Genero;
            filme.Diretor = filmenovo.Diretor;
            filme.Duracao = filmenovo.Duracao;
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
