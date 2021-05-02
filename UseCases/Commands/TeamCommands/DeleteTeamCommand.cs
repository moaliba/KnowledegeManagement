using CommandHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.TeamCommands
{
    public record DeleteTeamCommand(Guid TeamId) : Acommand(TeamId);
}
