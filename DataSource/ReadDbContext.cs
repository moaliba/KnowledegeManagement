using Microsoft.EntityFrameworkCore;
using ReadModels;
using ReadModels.ViewModel.Team;

namespace DataSource
{
    public class ReadDbContext : DbContext, IReadDbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TeamViewModel> TeamViewModels { get; set; }
    }
}
