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

        bool IsExist(string teamName);
    }
}
