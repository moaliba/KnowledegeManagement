using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.RepositoryContracts
{
    public interface ITeamRepository
    {
        void Add(Team team);

        bool DoesExist(string teamName);

        IEnumerable<Team> GetAllTeams();

        void Delete(Team team);

        Team Find(Guid id);

        void Update(Team team);
    }
     
}
