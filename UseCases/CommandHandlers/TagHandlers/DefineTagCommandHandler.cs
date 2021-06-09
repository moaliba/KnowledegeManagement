using CommandHandling.Abstractions;
using DomainModel;
using System;
using System.Threading.Tasks;
using UseCases.Commands.TagCommands;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.TagHandlers
{
    class DefineTagCommandHandler : IHandleCommand<DefineTagCommand>
    {
        readonly ITagRepository Tags;
        readonly ICategoryRepository Categories;


        public DefineTagCommandHandler(ITagRepository tags, ICategoryRepository categories)
        {
            Tags = tags;
            Categories = categories;
        }
      

        public Task Handle(DefineTagCommand command)
        {
            if(command.CategoryId != null)
                if(Categories.Find(command.CategoryId.Value) == null)
                    throw new Exception("Category does not exist");
            if (Tags.DoesExistInCategory(command.Title,command.CategoryId))
                throw new Exception("Tag already exists in this category");
            Tags.Add(Tag.DefineTag(command.Id, command.Title, command.CategoryId, command.DefinedFormPost));
            return Task.CompletedTask;
        }
    }
}
