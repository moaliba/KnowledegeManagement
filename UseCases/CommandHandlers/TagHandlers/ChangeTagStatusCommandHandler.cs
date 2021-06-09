using CommandHandling.Abstractions;
using DomainModel;
using System;
using System.Threading.Tasks;
using UseCases.Commands.TagCommands;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.TagHandlers
{
    public class ChangeTagStatusCommandHandler : IHandleCommand<ChangeTagStatusCommand>
    {
        readonly ITagRepository Tags;
        public ChangeTagStatusCommandHandler(ITagRepository tags)
        => Tags = tags;

        public Task Handle(ChangeTagStatusCommand command)
        {
            Tag tag = Tags.Find(command.Id);
            if (tag == null)
                throw new Exception("Tag is not found!!!");
            
            tag.ChangeTagStatus(command.Id,command.Status);
            Tags.Update(tag);
            return Task.CompletedTask;
        }
    }
}
