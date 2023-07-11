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

// Usuario
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<UsuarioController>();

// Multiplex

builder.Services.AddScoped<IMultiplexService, MultiplexService>();
builder.Services.AddScoped<MultiplexController>();

// Funcion
builder.Services.AddScoped<IFuncionService, FuncionService>();
builder.Services.AddScoped<FuncionController>();

// Sala
builder.Services.AddScoped<ISalaService, SalaService>();
builder.Services.AddScoped<SalaController>();

// Silla
builder.Services.AddScoped<ISillaService, SillaService>();
builder.Services.AddScoped<SillaController>();

// Snack
builder.Services.AddScoped<ISnackService, SnackService>();
builder.Services.AddScoped<SnackController>();

// Compra
builder.Services.AddScoped<ICompraService, CompraService>();
builder.Services.AddScoped<CompraController>();

// Item
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICompraService, CompraService>();
builder.Services.AddScoped<CompraService>();
builder.Services.AddScoped<ItemService>();

// Boleta
builder.Services.AddScoped<IBoletaService, BoletaService>();

// Inventario
builder.Services.AddScoped<IInventarioService, InventarioService>();
builder.Services.AddScoped<InventarioController>();


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
