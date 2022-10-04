using AutoMapper;
using FilmesAPI.data.dtos.Gerente;
using FilmesAPI.models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select(c => new { c.Id,c.Nome,c.Endereco,c.EnderecoId})));
        }
    }
}
