using ADSProject.Db;
using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Repositores;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configuracion BDCOntext
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer("name=DefaultConnection"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configuration =>
    {
        configuration
        .WithOrigins(builder.Configuration["allowedOrigin"]!)
        .AllowAnyMethod()
        .AllowAnyHeader();

    });
});

builder.Services.AddSwaggerGen();


//Configurando inyeccion de Dependencias
//builder.Services.AddSingleton<IEstudiante, EstudianteRepository>();
builder.Services.AddScoped<IEstudiante, EstudianteRepository>();
builder.Services.AddScoped<IECarrera,CarreraRepository>();
builder.Services.AddScoped<IMateria, MateriaRepository>();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
