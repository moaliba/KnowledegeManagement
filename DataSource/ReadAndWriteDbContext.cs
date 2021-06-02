using DomainModel;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataSource.Mapping;
using ReadModels;
using ReadModels.ViewModel.Team;
using ReadModels.ViewModel;

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
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new TagMapping());
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TeamViewModel> TeamViewModels { get; set; }
        public DbSet<CategoryViewModel> CategoryViewModels { get; set; }
    }
}
