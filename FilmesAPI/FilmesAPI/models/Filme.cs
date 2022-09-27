using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório!")] //Define que um campo é obrigatório de ser passado
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório!")] //Define que um campo é obrigatório de ser passado
        public string Diretor { get; set; }
        [Required(ErrorMessage = "O campo gênero é obrigatório!")] //Define que um campo é obrigatório de ser passado
        public string Genero { get; set; }
        [Range(1,600,ErrorMessage = "A duração deve ter entre 1 e 600 minutos!")] // Define o valor mínimo de máximo
        public int Duracao { get; set; }
       
    }
}
