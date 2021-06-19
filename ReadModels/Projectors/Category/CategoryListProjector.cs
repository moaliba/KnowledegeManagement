using DomainEvents.Category;
using EventHandling.Abstractions;
using ReadModels.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.Projectors.Category
{
    public class CategoryListProjector : IHandleEvent<Categorydefined>, IHandleEvent<CategoryPropertiesChanged>, IHandleEvent<CategoryStatusChanged>
    {
        private readonly IReadDbContext dbContext;
        public CategoryListProjector(IReadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Handle(CategoryPropertiesChanged e)
        {
            CategoryViewModel category = dbContext.CategoryViewModels.FirstOrDefault(c => c.CategoryId == e.CategoryId);
            if (category == null)
                throw new Exception("Category Not Found.");
            category.CategoryTitle = e.CategoryTitle;
            dbContext.CategoryViewModels.Update(category);
            return Task.CompletedTask;
        }

        public Task Handle(Categorydefined e)
        {
            dbContext.CategoryViewModels.Add(new CategoryViewModel()
            {
                CategoryId = e.CategoryId,
                CategoryTitle = e.CategoryTitle,
                CategoryIsActive = e.CategotyIsActive
            });
            return Task.CompletedTask;
        }

        public Task Handle(CategoryStatusChanged e)
        {
            CategoryViewModel category = dbContext.CategoryViewModels.FirstOrDefault(c => c.CategoryId == e.CategoryId);
            if (category == null)
                throw new Exception("Category Not Found.");
            category.CategoryIsActive = e.IsActive;
            dbContext.CategoryViewModels.Update(category);
            return Task.CompletedTask;
        }
    }
}
