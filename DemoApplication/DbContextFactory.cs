using Mehdime.Entity;
using Numero3.EntityFramework.Demo.DatabaseContext;
using System.Data.Entity;

namespace Numero3.EntityFramework.Demo
{
    public sealed class DbContextFactory : IDbContextFactory
    {
        private readonly string nameOrConnectionStringDefault;

        public DbContextFactory(string nameOrConnectionStringDefault)
        {
            this.nameOrConnectionStringDefault = nameOrConnectionStringDefault;
        }

        public TDbContext CreateDbContext<TDbContext>(string nameOrConnectionString) where TDbContext : DbContext
        {
            return new UserManagementDbContext(nameOrConnectionString ?? nameOrConnectionStringDefault) as TDbContext;
        }
    }
}
