using CommandHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.TeamCommands
{
    public record ChangeTeamTitleCommand(Guid TeamId, string Title) : Acommand(TeamId)
    {
        public static ChangeTeamTitleCommand Create(Guid TeamId, string Title)
        {
            if (Title.Trim().Length == 0)
                throw new Exception("Title must be not null and empty.");
            return new ChangeTeamTitleCommand(TeamId, Title);
        }
    }
}
