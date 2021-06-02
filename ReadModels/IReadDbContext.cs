using Microsoft.EntityFrameworkCore;
using ReadModels.ViewModel;
using ReadModels.ViewModel.Tag;
using ReadModels.ViewModel.Team;

namespace ReadModels
{
    public interface IReadDbContext
    {
       public DbSet<TeamViewModel> TeamViewModels { get; set; }
       public DbSet<TagViewModel> TagViewModels { get; set; }
       public DbSet<CategoryViewModel> CategoryViewModels { get; set; }
    }
}
