using Microsoft.EntityFrameworkCore;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Team;

namespace ReadModels
{
    public interface IReadDbContext
    {
        public DbSet<TeamViewModel> TeamViewModels { get; set; }
        public DbSet<CategoryViewModel> CategoryViewModels { get; set; }
    }
}
