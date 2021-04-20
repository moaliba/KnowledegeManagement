using DomainModel;
using System.Linq;
using UseCases.RepositoryContracts;
using UseCases.RepositoryInfrastractureContracts;

namespace DataAccess.Repositories
{
    public class TeamRepository : Repository, ITeamRepository
    {
        public TeamRepository(IWriteDBContext dBContext) : base(dBContext)
        {
        }

        public void Add(Team team)
        {
            _dbContex.Team.Add(team);
            SaveChanges();
        }

        public bool IsExist(string teamName) => _dbContex.Team.FirstOrDefault(c => c.Title == teamName) != null;
    }
}
