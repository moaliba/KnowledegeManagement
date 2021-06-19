using DomainEvents.Tag;
using EventHandling.Abstractions;
using ReadModels.ViewModel.Tag;
using System;
using System.Threading.Tasks;

namespace ReadModels.Projectors
{
    public class TagListProjector : IHandleEvent<TagDefined>, IHandleEvent<TagStatusChanged>, IHandleEvent<TagDeleted>, IHandleEvent<TagPropertiesChanged>
    {
        readonly IReadDbContext dbContext;

        public TagListProjector(IReadDbContext dbContext)
        => this.dbContext = dbContext;

        public Task Handle(TagDefined e)
        {
            var Category = dbContext.CategoryViewModels.Find(e.CategoryId);
            string CategoryName = Category != null ? Category.Title : string.Empty;

            dbContext.TagViewModels.Add(new TagViewModel
            {
                Id = e.Id,
                Title = e.Title,
                CategoryId = e.CategoryId,
                CategoryName = CategoryName,
                UserId = Guid.NewGuid(),
                IsActive=e.IsActive,
                UsedCount = e.DefinedFormPost ? 1 : 0
            });

            return Task.CompletedTask;
        }

        public Task Handle(TagStatusChanged e)
        {
            TagViewModel tagViewModel = dbContext.TagViewModels.Find(e.Id);
            if (tagViewModel == null)
                throw new Exception("Team is not found!!!");
            tagViewModel.IsActive = e.IsActive;

            return Task.CompletedTask;
        }

        public Task Handle(TagDeleted e)
        {
            TagViewModel tag = dbContext.TagViewModels.Find(e.Id);
            if (tag == null)
                throw new Exception("Team is not found!!!");
            dbContext.TagViewModels.Remove(tag);
            return Task.CompletedTask;
        }

        public Task Handle(TagPropertiesChanged e)
        {

            TagViewModel tagViewModel = dbContext.TagViewModels.Find(e.Id);
            if (tagViewModel == null)
                throw new Exception("Team is not found!!!");

            if (tagViewModel.CategoryId != e.CategoryId)
            {
                var Category = dbContext.CategoryViewModels.Find(e.CategoryId);
                string CategoryName = Category != null ? Category.Title : string.Empty;

                tagViewModel.CategoryId = e.CategoryId;
                tagViewModel.CategoryName = CategoryName;
            }

            tagViewModel.Title = e.Title;
            tagViewModel.IsActive = e.IsActive;

            return Task.CompletedTask;
        }
    }
}
