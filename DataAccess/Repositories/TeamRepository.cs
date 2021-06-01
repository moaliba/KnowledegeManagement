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

        public TeamRepository(IWriteDbContext dBContext, IEventBus eventBus) : base(dBContext)
        {
            this.eventBus = eventBus;
        }

        public void Add(Team team)
        {
            foreach (AnEvent e in team.Events)
                eventBus.Publish(e);
            team.ClearEvents();
            dbContext.Teams.Add(team);
        }

        public bool IsExist(string teamName) => dbContext.Teams.FirstOrDefault(c => c.Title == teamName) != null;

        public IEnumerable<Team> GetAllTeams() => dbContext.Teams;


        public Team Find(Guid id)
        {
            return dbContext.Teams.Find(id);
        }

        public void Delete(Team team)
        {
            dbContext.Teams.Remove(team);
        }

        public void Update(Team team)
        {
            //_dbContex.Teams.Update(team);
        }

    
    }
}
