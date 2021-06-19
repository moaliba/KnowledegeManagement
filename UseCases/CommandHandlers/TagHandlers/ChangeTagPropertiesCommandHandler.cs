using CommandHandling.Abstractions;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CommandHandlers.TagCommands;
using UseCases.Exceptions;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.TagHandlers
{
    public class ChangeTagPropertiesCommandHandler: IHandleCommand<ChangeTagPropertiesCommand>
    {
        readonly ITagRepository Tags;
        public ChangeTagPropertiesCommandHandler(ITagRepository tags)
        => Tags = tags;


        public Task Handle(ChangeTagPropertiesCommand command)
        {
            Tag tag = Tags.Find(command.Id);
            if (tag == null)
                throw new NotFoundException("Tag is not found!!!");

            tag.ChangeTagProperties(command.Id, command.Title,command.CategoryId,command.IsActive);
            Tags.Update(tag);
            return Task.CompletedTask;
        }
    }
}
