using CommandHandling.Abstractions;
using System;

namespace Commands.TeamCommands
{
    public record DefineTeamCommand(Guid TeamId, string Title) : Acommand(TeamId)
    {
        public static DefineTeamCommand Create(Guid TeamId, string Title)
        {
            if (Title.Trim().Length == 0)
                throw new Exception("Title must be not null and empty.");
            return new DefineTeamCommand(TeamId, Title);
        }
    }
}
