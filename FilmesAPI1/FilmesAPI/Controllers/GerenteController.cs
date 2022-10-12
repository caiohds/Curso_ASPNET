using AutoMapper;
using FilmesAPI.data;
using FilmesAPI.data.dtos.Gerente;
using FilmesAPI.models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        GerenteService _gerenteService;
        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }
        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto dto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionarGerente(dto);
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = readDto.Id }, readDto);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId (int id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperaGerentesPorId(id);
            if(readDto == null) return NotFound();
            return Ok(readDto);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result resultado = _gerenteService.DeletaGerente(id);
            if(resultado.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}
