using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public interface IWriteDBContext 
    {
        public DbSet<Team> Teams { get; set; }
    }
}
