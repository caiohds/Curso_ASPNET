using AutoMapper;
using FilmesAPI.data;
using FilmesAPI.data.dtos.Sessao;
using FilmesAPI.models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {

        private SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }
        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(dto);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readDto.SessaoId }, readDto);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.ResuperaSessaoPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }
    }
}
