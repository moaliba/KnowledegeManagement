using CommandHandling.Abstractions;
using DomainEvents;
using EventHandling.Abstractions;
using System;
using System.Threading.Tasks;

namespace UseCases.Reactors
{
    public class TeamDefinedReactor : IHandleEvent<TeamDefined>
    {
        private readonly ICommandBus commandBus;
        public TeamDefinedReactor(ICommandBus commandBus)
        => this.commandBus = commandBus;

        public Task Handle(TeamDefined e)
        {
            //this.commandBus.Send(new command())
            Console.WriteLine("Province added and reactions triggered!!!");
            return Task.CompletedTask;
        }
    }
}
