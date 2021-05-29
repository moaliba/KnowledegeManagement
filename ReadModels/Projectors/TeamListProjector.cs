using DomainEvents;
using EventHandling.Abstractions;
using System;
using System.Threading.Tasks;

namespace ReadModels.Projectors
{
    public class TeamListProjector : IHandleEvent<TeamDefined>
    {
        private readonly IReadDbContext dbContext;
        public TeamListProjector(IReadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Handle(TeamDefined e)
        {
            ////dbContext.ProvinceViewModels.Add(new ProvinceViewModel
            ////{
            ////    Id = e.id,
            ////    Name = e.Name
            ////});
            //dbContext.SaveChanges()
            Console.WriteLine("PROVINCE ADDED PROJECTED!!!!!!!!!!!");
            return Task.CompletedTask;
        }
    }
}
