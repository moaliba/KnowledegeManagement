using DomainEvents.Post;
using EventHandling.Abstractions;
using ReadModels.ViewModel.Post;
using System;
using System.Threading.Tasks;

namespace ReadModels.Projectors.Post
{
    public class PostListProjector : IHandleEvent<PostCreated>
    {
        private readonly IReadDbContext readDbContext;
        public PostListProjector(IReadDbContext readDbContext)
        {
            this.readDbContext = readDbContext;
        }

        public Task Handle(PostCreated e)
        {
            readDbContext.PostViewModels.Add(new PostViewModel()
            {
                CategoryID = e.CategoryId,
                PostContent = e.PostContent,
                PostId = e.PostId,
                PostTitle = e.PostTitle,
                Tags = e.Tags,
                UserID = e.UserId,
                RegisterDate = DateTime.Now
            });
            return Task.CompletedTask;
        }
    }
}
