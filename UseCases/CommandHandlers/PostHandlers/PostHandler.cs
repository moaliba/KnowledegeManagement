using CommandHandling.Abstractions;
using DomainModel;
using System.Threading.Tasks;
using UseCases.Commands.Post;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.PostHandlers
{
    public class PostHandler : IHandleCommand<PostCommand>
    {
        private readonly IPostRepository posts;
        private readonly ICategoryRepository Categories;
        public PostHandler(IPostRepository posts, ICategoryRepository Categories)
        {
            this.posts = posts;
            this.Categories = Categories;
        }

        public Task Handle(PostCommand command)
        {
            if (Categories.Find(command.CategoryId) == null)
                throw new System.Exception("Category does not exist!!");
            posts.Add(Post.DefinePost(command.Id, command.PostTitle, command.PostContent, command.CategoryId, command.UserId, command.Tags));
            return Task.CompletedTask;
        }
    }
}
