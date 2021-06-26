using DomainModel;
using EventHandling.Abstractions;
using System;
using System.Linq;
using UseCases.RepositoryContracts;

namespace DataAccess.Repositories
{
    public class PostRepository : Repository, IPostRepository
    {
        private readonly IEventBus eventBus;
        private readonly IPostAttachmentRepository postAttachmentRepository;

        public PostRepository(IWriteDbContext dbContext, IEventBus eventBus, IPostAttachmentRepository postAttachmentRepository) : base(dbContext)
        {
            this.eventBus = eventBus;
            this.postAttachmentRepository = postAttachmentRepository;
        }

        public void Add(Post post)
        {
            try
            {

                dbContext.Posts.Add(post);
            }
            catch (Exception ex)
            {
                throw new Exception("RepError1:" + ex.Message);
            }
            foreach (PostAttachment attachment in post.AttachmentList)
            {
                string FilePath = postAttachmentRepository.Add(attachment);
                try
                {

                    post.AddFile(attachment.Id, FilePath);
                }
                catch (Exception ex)
                {
                    throw new Exception("RepError2:" + ex.Message);
                }
            }
            foreach (var @event in post.Events)
                eventBus.Publish(@event);
            post.ClearEvents();
        }

        public Post Find(Guid Id)
        => dbContext.Posts.FirstOrDefault(c => c.Id == Id);

        public int PostCount(Guid? categoryId)
       => dbContext.Posts.Count(c => c.CategoryId == categoryId || categoryId == null);
    }
}
