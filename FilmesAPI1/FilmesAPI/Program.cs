using FilmesAPI.data;
using FilmesAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<FilmeService,FilmeService>();
builder.Services.AddScoped<CinemaService,CinemaService>();
builder.Services.AddScoped<EnderecoService,EnderecoService>();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("CinemaConnection"), new MySqlServerVersion(new Version(8, 0))));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();