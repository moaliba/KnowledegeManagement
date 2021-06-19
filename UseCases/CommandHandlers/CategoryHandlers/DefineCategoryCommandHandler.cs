using CommandHandling.Abstractions;
using DomainModel;
using System;
using System.Threading.Tasks;
using Commands.CategoryCommands;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.CategoryHandlers
{
    public class DefineCategoryCommandHandler : IHandleCommand<DefineCategoryCommand>
    {
        readonly ICategoryRepository Categories;
        public DefineCategoryCommandHandler(ICategoryRepository categoryRepository)
        => Categories = categoryRepository;


        public Task Handle(DefineCategoryCommand command)
        {
            if (Categories.DeosExist(command.Title))
                throw new Exception("Team is already exist!!!");
            Categories.Create(Category.DefineCategory(command.Id, command.Title, command.IsActive));
            return Task.CompletedTask;
        }
    }
}
