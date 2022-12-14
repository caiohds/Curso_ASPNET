using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Data;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var y = builder.Configuration.GetValue<string>("admininfo:password");

// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(opts =>
opts.UseMySql(builder.Configuration.GetConnectionString("UsuarioConnection"), new MySqlServerVersion(new Version(8, 0))));
builder.Services.AddIdentity<CustomIdentityUser, IdentityRole<int>>(
    opts => opts.SignIn.RequireConfirmedEmail = true)
    .AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<CadastroService, CadastroService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<EmailService, EmailService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddUserSecrets<Program>(true);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
