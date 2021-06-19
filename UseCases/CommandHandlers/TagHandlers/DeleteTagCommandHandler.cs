using CommandHandling.Abstractions;
using System.Threading.Tasks;
using UseCases.Commands.TagCommands;
using UseCases.Exceptions;
using UseCases.RepositoryContracts;



namespace UseCases.CommandHandlers.TagHandlers
{
    public class DeleteTagCommandHandler : IHandleCommand<DeleteTagCommand>
    {
        readonly ITagRepository Tags;

        public DeleteTagCommandHandler(ITagRepository tags)
        =>Tags = tags;
        
        public Task Handle(DeleteTagCommand command)
        {
            var Tag = Tags.Find(command.Id);
            if (Tag == null)
                throw new NotFoundException("Tag is not found!!!");
            Tag.Remove();
            Tags.Delete(Tag);
            return Task.CompletedTask;
            
        }
    }
}
