using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace UseCases.RepositoryInfrastractureContracts
{
    public interface IWriteDBContext 
    {
        public DbSet<Team> Teams { get; set; }
    }
}
