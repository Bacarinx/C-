using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using OrderSolution.API.Entities;

namespace OrderSolution.API.Context
{
    public class OrderSolutionDbContext : DbContext
    {
        public OrderSolutionDbContext(DbContextOptions<OrderSolutionDbContext> opt) : base (opt) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
