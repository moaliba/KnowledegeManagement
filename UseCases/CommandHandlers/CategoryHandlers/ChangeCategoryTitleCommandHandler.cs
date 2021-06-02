using CommandHandling.Abstractions;
using Commands.CategoryCommands;
using DomainModel;
using System;
using System.Threading.Tasks;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.CategoryHandlers
{
    public class ChangeCategoryTitleCommandHandler : IHandleCommand<ChangeCategoryTitleCommand>
    {
        readonly ICategoryRepository Categories;
        public ChangeCategoryTitleCommandHandler(ICategoryRepository categoryRepository)
        => Categories = categoryRepository;

        public Task Handle(ChangeCategoryTitleCommand command)
        {
            Category category = Categories.Find(command.Id);
            if (category == null)
                throw new Exception("Category not found.");
            if (Categories.DeosExist(command.Title))
                throw new Exception("Title is alreay exist.");
            category.ReName(command.Id, command.Title);
            Categories.Update(category);
            return Task.CompletedTask;
        }
    }
}
