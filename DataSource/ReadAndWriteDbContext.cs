using DomainModel;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataSource.Mapping;
using ReadModels;
using ReadModels.ViewModel.Team;

namespace DataSource
{
    public class ReadAndWriteDbContext : DbContext, IWriteDbContext, IUnitOfWork, IReadDbContext
    {
        public ReadAndWriteDbContext(DbContextOptions<ReadAndWriteDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TeamMapping());
            modelBuilder.ApplyConfiguration(new GroupMapping());
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamViewModel> TeamViewModels { get; set; }
    }
}
