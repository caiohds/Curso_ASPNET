using AutoMapper;
using FilmesAPI.data;
using FilmesAPI.data.dtos.Gerente;
using FilmesAPI.models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadGerenteDto AdicionarGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }
        public ReadGerenteDto RecuperaGerentesPorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return gerenteDto;
            }
            return null;
        }

        public Result DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado!");
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
