using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class EfetuaResetRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string Senha{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ReSenha{ get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string  Token{ get; set; }
    }
}
