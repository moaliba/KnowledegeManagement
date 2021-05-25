using CommandHandling.Abstractions;
using Commands.TeamCommands;
using DomainModel;
using System;
using System.Threading.Tasks;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.TeamHandlers
{
    class ChangeTeamTitleCommandHandler : IHandleCommand<ChangeTeamTitleCommand>
    {

        readonly ITeamRepository teamRepository;
        public ChangeTeamTitleCommandHandler(ITeamRepository teamRepository)
       => this.teamRepository = teamRepository;

        public Task Handle(ChangeTeamTitleCommand command)
        {
            Team team = teamRepository.Find(command.Id);
            if (team == null)
                throw new Exception("Team is not found!!!");
            else if (teamRepository.IsExist(command.Title))
                throw new Exception("Title  already exists!!!");
            else
            {
                team.Rename(command.Title);
               // team.Title = command.Title;
                teamRepository.Update(team);
            }
            

           return Task.CompletedTask;
        }
    }
}
