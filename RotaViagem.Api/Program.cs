using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using RotaViagem.Application.Handlers.Rotas;
using RotaViagem.Domain.Repositories;
using RotaViagem.Infra.Contexts;
using RotaViagem.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//DI - Injecao de Dependencias
builder.Services.AddDbContext<DataContext>(x => 
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//DI - Injecao de Dependencias

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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