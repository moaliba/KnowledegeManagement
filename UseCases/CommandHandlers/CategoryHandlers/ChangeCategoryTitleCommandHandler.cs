using CommandHandling.Abstractions;
using Commands.CategoryCommands;
using DomainModel;
using System;
using System.Threading.Tasks;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.CategoryHandlers
{
    public class ChangeCategoryTitleCommandHandler : IHandleCommand<ChangeCategoryPropertiesCommand>
    {
        readonly ICategoryRepository Categories;
        public ChangeCategoryTitleCommandHandler(ICategoryRepository categoryRepository)
        => Categories = categoryRepository;

        public Task Handle(ChangeCategoryPropertiesCommand command)
        {
            Category category = Categories.Find(command.Id);
            if (category == null)
                throw new Exception("Category not found.");
            //if (Categories.DeosExist(command.Title))
            //    throw new Exception("Title is alreay exist.");
            category.ChangeProperties(command.Id, command.Title, command.IsActive);
            Categories.Update(category);
            return Task.CompletedTask;
        }
    }
}
