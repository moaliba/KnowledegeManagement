using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace ReadModels
{
    public interface IReadDbContext
    {
       public DbSet<Team> Teams { get; set; }
    }
}
