using CommandHandling.Abstractions;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Commands.TagCommands;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.TagHandlers
{
    class DefineTagCommandHandler : IHandleCommand<DefineTagCommand>
    {
        readonly ITagRepository Tags;
        

        public DefineTagCommandHandler(ITagRepository tags)
        =>  Tags = tags;
      

        public Task Handle(DefineTagCommand command)
        {
            if (Tags.DoesExist(command.Title,command.CategoryId))
                throw new Exception("Tag already exists");
            Tags.Add(Tag.DefineTag(command.Id, command.Title, command.CategoryId));
            return Task.CompletedTask;
        }
    }
}
