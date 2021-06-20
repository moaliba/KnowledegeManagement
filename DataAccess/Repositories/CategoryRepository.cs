using DomainModel;
using EventHandling.Abstractions;
using System;
using System.Linq;
using UseCases.RepositoryContracts;

namespace DataAccess.Repositories
{
    public class CategoryRepository : Repository, ICategoryRepository
    {
        readonly IEventBus eventBus;
        public CategoryRepository(IWriteDbContext dbContext, IEventBus eventBus) : base(dbContext)
        => this.eventBus = eventBus;

        public void Create(Category category)
        {
            foreach (AnEvent @event in category.Events)
            {
                eventBus.Publish(@event);
            }
            category.ClearEvents();
            dbContext.Categories.Add(category);
        }

        public void Delete(Category category)
        {
            foreach (AnEvent @event in category.Events)
                eventBus.Publish(@event);
            category.ClearEvents();
            dbContext.Categories.Remove(category);
        }

        public bool DeosExist(string title)
        => dbContext.Categories.FirstOrDefault(c => c.Title == title) != null;

        public Category Find(Guid Id)
        => dbContext.Categories.FirstOrDefault(c => c.Id == Id);

        public void Update(Category category)
        {
            foreach (AnEvent @event in category.Events)
            {
                eventBus.Publish(@event);
            }
            category.ClearEvents();
        }
    }
}
