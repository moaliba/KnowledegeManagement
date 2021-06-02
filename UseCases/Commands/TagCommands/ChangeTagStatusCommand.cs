using CommandHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Commands.TagCommands
{
    public record ChangeTagStatusCommand(Guid Id,bool Status) : Acommand(Id);
   
}
