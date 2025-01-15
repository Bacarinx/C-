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
  var res = await context.Contatos.ToListAsync();
  if(res == null) return Results.NotFound();
  return Results.Ok(res);
});

app.MapGet("/Contatos/{Id}", async (AgendaContext context, int id) =>
{
  var res = await context.Contatos.FirstOrDefaultAsync(u => u.Id == id);

  if(res == null) 
    return Results.NotFound();

  return Results.Ok(res);
});

app.MapPost("/Contatos", async(Contato contato, AgendaContext context) =>
{
  context.Contatos.Add(contato);
  await context.SaveChangesAsync();
});

app.Run();
