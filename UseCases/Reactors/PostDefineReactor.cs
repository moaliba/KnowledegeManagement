using CommandHandling.Abstractions;
using DomainEvents.Post;
using EventHandling.Abstractions;
using System;
using System.Threading.Tasks;
using UseCases.Commands.TagCommands;
using UseCases.RepositoryContracts;

namespace UseCases.Reactors
{
    public class PostDefineReactor : IHandleEvent<PostCreated>
    {
        private readonly ICommandBus CommandBus;
        readonly ITagRepository Tags;

        public PostDefineReactor(ICommandBus commandBus, ITagRepository tags)
        {
            CommandBus = commandBus;
            Tags = tags;
        }

        public Task Handle(PostCreated e)
        {
            string Posttags = e.Tags;
            string[] tagList = Posttags.Split(new char[] { ',' });
            for (int i = 0; i < tagList.Length ; i++)
            {
                if (!Tags.DoesExistInCategory(tagList[i], e.CategoryId))
                    CommandBus.Send(DefineTagCommand.Create(Guid.NewGuid(), tagList[i], e.CategoryId, true));
            }
            return Task.CompletedTask;
          
        }
    }
}
