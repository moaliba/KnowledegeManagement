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
            string CategoryTitle = readDbContext.CategoryViewModels.FirstOrDefault(c => c.Id == e.CategoryId).Title;
            readDbContext.PostViewModels.Add(new PostViewModel()
            {
                CategoryID = e.CategoryId,
                CategoryTitle = CategoryTitle,
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
                if (tag != null)
                {
                    tag.UsedCount += 1;
                    readDbContext.TagViewModels.Update(tag);
                }
            }

            return Task.CompletedTask;
        }
    }
}
