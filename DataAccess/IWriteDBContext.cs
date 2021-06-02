using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public interface IWriteDbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
