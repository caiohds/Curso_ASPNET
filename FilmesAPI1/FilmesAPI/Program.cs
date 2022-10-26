using FilmesAPI.Authorization;
using FilmesAPI.data;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<FilmeService,FilmeService>();
builder.Services.AddScoped<CinemaService,CinemaService>();
builder.Services.AddScoped<EnderecoService,EnderecoService>();
builder.Services.AddScoped<SessaoService, SessaoService>();
builder.Services.AddScoped<GerenteService, GerenteService>();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("CinemaConnection"), new MySqlServerVersion(new Version(8, 0))));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(token =>
{
    token.RequireHttpsMetadata = false;
    token.SaveToken = true;
    token.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IdadeMinima", policy =>
    {
        policy.Requirements.Add(new IdadeMinimaRequired(18))
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();