using DomainModel;
using Microsoft.EntityFrameworkCore;
using UseCases.RepositoryInfrastractureContracts;

namespace DataSource
{
    public class WriteDBContext : DbContext, IWriteDBContext, IUnitOfWork
    {
        public WriteDBContext(DbContextOptions<WriteDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Team> Teams { get; set; }
    }
}
