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
builder.Services.AddScoped<IDeleteIntService, UsuarioService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<UsuarioController>();


builder.Services.AddScoped<IEntityService<Multiplex>, MultiplexService>();
builder.Services.AddScoped<IDeleteIntService, MultiplexService>();
builder.Services.AddScoped<IReadService, MultiplexService>();
builder.Services.AddScoped<MultiplexService>();
builder.Services.AddScoped<MultiplexController>();

builder.Services.AddScoped<IEntityService<Funcion>, FuncionService>();
builder.Services.AddScoped<IDeleteIntService, FuncionService>();
builder.Services.AddScoped<IReadIntService, FuncionService>();
builder.Services.AddScoped<FuncionService>();
builder.Services.AddScoped<FuncionController>();

builder.Services.AddScoped<IEntityService<Sala>, SalaService>();
//builder.Services.AddScoped<IReadIntService, SalaService>();
builder.Services.AddScoped<IDeleteEntityService<Sala>, SalaService>();
builder.Services.AddScoped<SalaService>();
builder.Services.AddScoped<SalaController>();

builder.Services.AddScoped<IEntityService<Silla>, SillaService>();
builder.Services.AddScoped<IDeleteEntityService<Silla>, SillaService>();
builder.Services.AddScoped<IReadEntityService<Silla>, SillaService>();
builder.Services.AddScoped<SillaController>();



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
