using CommandHandling.Abstractions;
using DomainModel;
using System;
using System.Threading.Tasks;
using UseCases.Commands.CategoryCommands;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.CategoryHandlers
{
    public class DeleteCategoryCommandHandler : IHandleCommand<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository categories;
        private readonly IPostRepository posts;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IPostRepository postRepository)
        {
            categories = categoryRepository;
            posts = postRepository;
        }

        public Task Handle(DeleteCategoryCommand command)
        {
            Category category = categories.Find(command.id);
            if (category == null)
                throw new Exception("Category does not exist!!!");
            if (posts.PostCount(command.id) > 0)
                throw new Exception("category can not be deleted because used in some posts!!!");
            category.DeleteCategory(command.id);
            categories.Delete(category);
            return Task.CompletedTask;
        }
    }
}
