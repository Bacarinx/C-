using System;
using apiModule.Context;
using apiModule.Models;
using Microsoft.EntityFrameworkCore;

//------------------------Confirguração Padrão
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AgendaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection(); 

//-----------------------Camada de Controle
app.MapGet("/Contatos", async (AgendaContext context) =>
{
  await context.Contatos.ToListAsync();
});

app.MapPost("/Contatos", async(Contato contato, AgendaContext context) =>
{
  context.Contatos.Add(contato);
  await context.SaveChangesAsync();
  return Results.Created($"/Contatos/{contato.Id}", contato);
});

app.Run();
