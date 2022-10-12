using AutoMapper;
using FilmesAPI.data;
using FilmesAPI.data.dtos.Cinema;
using FilmesAPI.models;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinemaDto);
        }

        public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where
                                            cinema.Sessoes.
                                            Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;
                cinemas = query.ToList();
            }
            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }
            return null;
        }
    }
}
