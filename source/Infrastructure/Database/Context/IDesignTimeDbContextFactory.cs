using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Solution.Infrastructure.Database.Context
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Database;Integrated Security=true;Connection Timeout=5;";
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));

            return new DatabaseContext(builder.Options);
        }
    }
}
