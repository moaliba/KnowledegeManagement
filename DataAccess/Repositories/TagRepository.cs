using DomainModel;
using EventHandling.Abstractions;
using System;
using System.Linq;
using UseCases.RepositoryContracts;

namespace DataAccess.Repositories
{
    public class TagRepository : Repository, ITagRepository
    {

        readonly IEventBus EventBus;
        public TagRepository(IWriteDbContext dbContext, IEventBus eventbus) :base(dbContext)
        =>EventBus = eventbus;
       
        public void Add(Tag tag)
        {
            foreach (AnEvent e in tag.Events)
                EventBus.Publish(e);
            tag.ClearEvents();
            dbContext.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
            foreach (AnEvent e in tag.Events)
                EventBus.Publish(e);
            tag.ClearEvents();
        }

        public bool DoesExistInCategory(string title, Guid? categoryId)
        => dbContext.Tags.FirstOrDefault(t => t.Title == title && t.CategoryId==categoryId) != null;

        public Tag Find(Guid id)
        =>  dbContext.Tags.Find(id);

        public void Delete(Tag tag)
        {
            foreach (AnEvent e in tag.Events)
                EventBus.Publish(e);
            tag.ClearEvents();
            dbContext.Tags.Remove(tag);
        }
    }
}
