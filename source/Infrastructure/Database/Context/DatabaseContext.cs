using Microsoft.EntityFrameworkCore;
using Solution.CrossCutting.EntityFrameworkCore;

namespace Solution.Infrastructure.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly();
            DatabaseContextSeed.Seed(modelBuilder);
        }
    }
}
