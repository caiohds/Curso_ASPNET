using Model = FilmesAPI.models;
namespace FilmesAPI.data.dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int SessaoId { get; set; }
        public Model.Cinema Cinema { get; set; }
        public Model.Filme Filme { get; set; }
        public DateTime Encerramento { get; set; }
        public DateTime Inciio { get; set; }
    }
}
