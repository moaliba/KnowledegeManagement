using CommandHandling.Abstractions;
using Commands.TeamCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Commands.TagCommands
{
    public record DefineTagCommand(Guid Id,string Title,Guid CategoryId) : Acommand(Id)
    {
        public static DefineTagCommand Create(Guid id, string title, Guid categoryId)
        {
            if (title.Trim().Length == 0)
                throw new Exception("Title must be not null and empty.");
            return new DefineTagCommand(id, title,categoryId);
        }
    }
    
}
