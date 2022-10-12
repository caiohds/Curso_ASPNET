using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Data;
using UsuariosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(opts =>
opts.UseMySql(builder.Configuration.GetConnectionString("UsuarioConnection"), new MySqlServerVersion(new Version(8, 0))));
builder.Services.AddIdentity<IdentityUser<int>,IdentityRole<int>>().AddEntityFrameworkStores<UserDbContext>();
builder.Services.AddScoped<CadastroService, CadastroService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
