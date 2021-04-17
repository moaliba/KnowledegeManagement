using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.RepositoryContracts;

namespace DataAccess.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public void Add(Team team)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string teamName)
        {
            throw new NotImplementedException();
        }
    }
}
