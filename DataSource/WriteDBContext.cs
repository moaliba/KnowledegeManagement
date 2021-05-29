using DomainModel;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataSource.Mapping;

namespace DataSource
{
    public class WriteDBContext : DbContext, IWriteDBContext, IUnitOfWork
    {
        public WriteDBContext(DbContextOptions<WriteDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TeamMapping());
        }

        public DbSet<Team> Teams { get; set; }
    }
}
