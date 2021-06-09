using DomainEvents.Post;
using EventHandling.Abstractions;
using ReadModels.ViewModel.Post;
using ReadModels.ViewModel.Tag;
using System;
using System.Linq;
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

            string Posttags = e.Tags;
            string[] tagList = Posttags.Split(new char[] { ',' });
            for (int i = 0; i < tagList.Length; i++)
            {
                TagViewModel tag = readDbContext.TagViewModels.FirstOrDefault(c => c.Title == tagList[i] && c.CategoryId == e.CategoryId);
                tag.UsedCount += 1;
                if (tag != null)
                    readDbContext.TagViewModels.Update(tag);
            }

            return Task.CompletedTask;
        }
    }
}
