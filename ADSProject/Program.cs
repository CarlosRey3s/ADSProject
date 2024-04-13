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

builder.Services.AddSwaggerGen();


//Configurando inyeccion de Dependencias
builder.Services.AddSingleton<IEstudiante, EstudianteRepository>();
builder.Services.AddSingleton<IECarrera,CarreraRepository>();
builder.Services.AddSingleton<IMateria, MateriaRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
