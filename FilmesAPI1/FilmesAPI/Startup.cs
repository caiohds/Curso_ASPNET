using FilmesAPI.data;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FilmeContext>(opts => opts.UseMySQL(Configuration.GetConnectionString("FilmeConnection")));
        }
    }
}
