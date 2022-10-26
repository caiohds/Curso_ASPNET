using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI.Authorization
{
    public class IdadeMinimaRequired : IAuthorizationRequirement
    {
        public int IdadeMinima { get; set; }

        public IdadeMinimaRequired(int idadeMinima)
        {
            IdadeMinima = idadeMinima;
        }
    }
}
