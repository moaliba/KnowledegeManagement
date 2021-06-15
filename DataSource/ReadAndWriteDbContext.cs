using DomainModel;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataSource.Mapping;
using ReadModels;
using ReadModels.ViewModel.Team;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Tag;
using ReadModels.ViewModel.Post;

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
            modelBuilder.ApplyConfiguration(new PostMapping());
        }

        /////////////////////////////////////////////////////////Aggregates
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }

        /////////////////////////////////////////////////////////ReadModels
        public DbSet<TeamViewModel> TeamViewModels { get; set; }
        public DbSet<CategoryViewModel> CategoryViewModels { get; set; }
        public DbSet<TagViewModel> TagViewModels { get; set; }
        public DbSet<PostViewModel> PostViewModels { get; set; }

       
    }
}
