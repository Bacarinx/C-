using Microsoft.EntityFrameworkCore;
using TechLibrary.API.Entities;

namespace TechLibrary.API.Infrastructure.Context
{
    public class TechLibraryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\henri\\OneDrive\\Área de Trabalho\\Estudos\\C#\\TechLibrary\\TechLibraryDb.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
    }
}
