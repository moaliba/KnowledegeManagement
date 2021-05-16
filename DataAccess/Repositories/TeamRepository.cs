using DataSource;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.RepositoryContracts;
using UseCases.RepositoryInfrastractureContracts;


namespace DataAccess.Repositories
{
    public class TeamRepository : Repository, ITeamRepository
    {
        readonly IUnitOfWork _unitOfWork;
        public TeamRepository(IWriteDBContext dBContext, IUnitOfWork unitOfWork) : base(dBContext)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Add(Team team)
        {
            _dbContex.Teams.Add(team);
            //new WriteDBContext().SaveChanges();
            _unitOfWork.SaveChanges();
        }

        public bool IsExist(string teamName) => _dbContex.Teams.FirstOrDefault(c => c.Title == teamName) != null;

        public IEnumerable<Team> GetAllTeams() => _dbContex.Teams;


        public Team Find(Guid id)
        {
            return _dbContex.Teams.Find(id);
        }

        public void Delete(Team team)
        {
            _dbContex.Teams.Remove(team);
            _unitOfWork.SaveChanges();
        }

        public void Update(Team team)
        {
            
            _dbContex.Teams.Update(team);
            _unitOfWork.SaveChanges();
        }

    
    }
}
