using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.models
{
    public class Gerente
    {
        [Key]
        [Required]

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
