using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public interface IWriteDbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}
