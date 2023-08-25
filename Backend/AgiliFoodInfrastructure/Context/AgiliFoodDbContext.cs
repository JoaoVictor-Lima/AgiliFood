using AgiliFoodDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgiliFoodInfrastructure.Context
{
    public class AgiliFoodDbContext : DbContext
    {
        public AgiliFoodDbContext(DbContextOptions<AgiliFoodDbContext> options)
            : base(options) { }


        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento entre Product e Supplier
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products) 
                .HasForeignKey(p => p.SupplierId);

            // Configuração do relacionamento entre Order e Collaborator
            modelBuilder.Entity<Order>()
            .HasOne(c => c.Collaborator)
            .WithMany(c => c.Orders)
            .HasForeignKey(c => c.CollaboratorId);

            // Configuração do relacionamento entre Order e Collaborator
            modelBuilder.Entity<Order>()
            .HasMany(c => c.Products)
            .WithMany(p => p.Orders)
            .UsingEntity<Dictionary<string, object>>(
                "CompraProduto",
                j => j
                    .HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProductId"),
                j => j
                    .HasOne<Order>()
                    .WithMany()
                    .HasForeignKey("CompraId")
            );
        }
    }
}
