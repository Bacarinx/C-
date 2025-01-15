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

// app.MapGet("/Contatos/", async(AgendaContext context, string nome) =>
// {
//   var res = await context.Contatos.Where(c => EF.Functions.Like(c.Nome, $"%{nome}%")).ToListAsync();
  
//   if(res == null) return Results.NotFound("Nenhum Contato encontrado com esse nome!");

//   return Results.Ok();
// });

app.MapPost("/Contatos", async(Contato contato, AgendaContext context) =>
{
  context.Contatos.Add(contato);
  await context.SaveChangesAsync();
});

app.MapPatch("/Contatos/{id}", async (AgendaContext context, int id, Contato newContact) =>
{
  Contato res = await context.Contatos.FirstOrDefaultAsync(c => c.Id == id);

  if(res == null){
    return Results.NotFound("Contato não encontrado!");
  }

  res.Nome = newContact.Nome;
  res.Telefone = newContact.Telefone;
  res.Ativo = newContact.Ativo;
  
  await context.SaveChangesAsync();
  return Results.Ok();
});

app.MapDelete("/Contatos/{id}", async (AgendaContext context, int id) =>
{
  var res = await context.Contatos.FirstOrDefaultAsync(c => c.Id == id);
  if(res == null) return Results.NotFound("Contato não encontrado!");

  context.Contatos.Remove(res);
  await context.SaveChangesAsync();
  return Results.Ok("Exclusão realizada com sucesso!");
});

app.Run();
