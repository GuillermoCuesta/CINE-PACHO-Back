using Microsoft.Extensions.DependencyInjection;
using WebApi.Services;
using WebApi.Controllers;
using WebApi.Interfaces;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de los servicios personalizados
builder.Services.AddScoped<IEntityService<Usuario>, UsuarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<UsuarioController>();


builder.Services.AddScoped<IEntityService<Multiplex>, MultiplexService>();
builder.Services.AddScoped<MultiplexController>();

builder.Services.AddScoped<IEntityService<Funcion>, FuncionService>();

builder.Services.AddScoped<IEntityService<Sala>, SalaService>();
builder.Services.AddScoped<ISalaService, SalaService>();

builder.Services.AddScoped<IEntityService<Silla>, SillaService>();



//builder.Services.AddScoped<IEntityService, MultiplexService>();
//builder.Services.AddScoped<MultiplexController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
