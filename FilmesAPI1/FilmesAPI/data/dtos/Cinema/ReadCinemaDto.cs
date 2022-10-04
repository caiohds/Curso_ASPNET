using System.ComponentModel.DataAnnotations;
using Model = FilmesAPI.models;
namespace FilmesAPI.data.dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public Model.Endereco Endereco { get; set; }
        public Model.Gerente Gerente { get; set; }
    }
}
