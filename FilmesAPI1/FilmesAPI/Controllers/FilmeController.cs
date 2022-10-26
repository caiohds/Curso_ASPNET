using AutoMapper;
using FilmesAPI.data;
using FilmesAPI.data.dtos;
using FilmesAPI.data.dtos.Filme;
using FilmesAPI.models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {


        private FilmeService _filmeService;
        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles ="admin,regular")]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto>readDto = _filmeService.RecuperaFilmes(classificacaoEtaria);
            if(readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
           ReadFilmeDto filmeDto = _filmeService.ReacuperaFilmesPorId(id);
            
            if(filmeDto != null)
            {
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = _filmeService.AtualizarFilme(id, filmeDto);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = _filmeService.DeletaFilme(id);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }

    }
}
