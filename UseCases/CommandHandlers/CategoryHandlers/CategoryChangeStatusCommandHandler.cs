using CommandHandling.Abstractions;
using DomainModel;
using System;
using System.Threading.Tasks;
using UseCases.Commands.CategoryCommands;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.CategoryHandlers
{
    public class CategoryChangeStatusCommandHandler : IHandleCommand<CategoryChangeStatusCommand>
    {
        private readonly ICategoryRepository Categories;
        public CategoryChangeStatusCommandHandler(ICategoryRepository categoryRepository)
        => Categories = categoryRepository;

        public Task Handle(CategoryChangeStatusCommand command)
        {
            Category category = Categories.Find(command.Id);
            if (category == null)
                throw new Exception("Category not found.");
            category.ChangeStatus(command.Id, command.IsActive);
            Categories.Update(category);
            return Task.CompletedTask;
        }
    }
}
