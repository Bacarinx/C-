using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using OrderSolution.API.Entities;

namespace OrderSolution.API.Context
{
    public class OrderSolutionDbContext : DbContext
    {
        #pragma warning disable IDE0290
        public OrderSolutionDbContext(DbContextOptions<OrderSolutionDbContext> opt) : base(opt) { }

        public required DbSet<User> Users { get; set; }
        public required DbSet<Category> Categories { get; set; }
        public required DbSet<Product> Products { get; set; }
        public required DbSet<Client> Clients { get; set; }
    }
}
