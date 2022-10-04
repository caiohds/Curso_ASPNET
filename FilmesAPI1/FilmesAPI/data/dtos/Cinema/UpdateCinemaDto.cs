using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.data.dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
