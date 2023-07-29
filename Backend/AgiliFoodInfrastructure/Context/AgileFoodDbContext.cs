using AgiliFoodDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgiliFoodInfrastructure.Context
{
    public class AgileFoodDbContext : DbContext
    {
        public AgileFoodDbContext(DbContextOptions<AgileFoodDbContext> options)
            : base(options) { }


        public DbSet<Supplier> Supplier { get; set; }

    }
}
