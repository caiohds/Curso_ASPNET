using AutoMapper;
using FilmesAPI.data.dtos.Sessao;
using FilmesAPI.models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.Inciio, opts => opts.MapFrom(dto => dto.Encerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}

