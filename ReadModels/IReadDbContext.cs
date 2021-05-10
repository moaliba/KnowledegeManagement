using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace ReadModels
{
    public interface IReadDbContext
    {
        DbSet<Team> Teams { get; set; }
    }
}
