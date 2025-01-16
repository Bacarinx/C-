using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiModule.Models;
using Microsoft.EntityFrameworkCore;

namespace apiModule.Context
{
    public class AgendaContext : DbContext
    {
      public AgendaContext(DbContextOptions<AgendaContext> options) : base(options){
      Contatos = Set<Contato>();
    } 
      public DbSet<Contato> Contatos { get; set; } //confirgurando a tabela de contatos referenciando a classe Contato  
  }
}