using DomainModel;
using EventHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.RepositoryContracts;


namespace DataAccess.Repositories
{
    public class TeamRepository : Repository, ITeamRepository
    {
        public IEventBus eventBus { get; set; }

        public TeamRepository(IWriteDBContext dBContext, IEventBus eventBus) : base(dBContext)
        {
            this.eventBus = eventBus;
        }

        public void Add(Team team)
        {
            foreach (AnEvent e in team.Events)
                eventBus.Publish(e);
            team.ClearEvents();
            _dbContex.Teams.Add(team);
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
        }

        public void Update(Team team)
        {
            //_dbContex.Teams.Update(team);
        }

    
    }
}
