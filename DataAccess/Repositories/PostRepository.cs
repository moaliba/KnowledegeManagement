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

        public PostRepository(IWriteDbContext dbContext, IEventBus eventBus) : base(dbContext)
        => this.eventBus = eventBus;

        public void Add(Post post)
        {
            foreach (var @event in post.Events)
                eventBus.Publish(@event);
            post.ClearEvents();
            dbContext.Posts.Add(post);
        }

        public Post Find(Guid Id)
        => dbContext.Posts.FirstOrDefault(c => c.Id == Id);
    }
}
