using DomainEvents.Tag;
using EventHandling.Abstractions;
using ReadModels.ViewModel.Tag;
using System;
using System.Threading.Tasks;

namespace ReadModels.Projectors
{
    public class TagListProjector : IHandleEvent<TagDefined> , IHandleEvent<TagStatusChanged>
    {
        readonly IReadDbContext dbContext;

        public TagListProjector(IReadDbContext dbContex)
        => this.dbContext = dbContex;
       
        public Task Handle(TagDefined e)
        {
            var Category = dbContext.CategoryViewModels.Find(e.CategoryId);
            string CategoryName = Category!=null ? Category.CategoryTitle : string.Empty; 

            dbContext.TagViewModels.Add(new TagViewModel
            {
                Id = e.Id,
                Title=e.Title,
                CategoryId=e.CategoryId,
                CategoryName= CategoryName,
                UserId=Guid.NewGuid()
            });

            return Task.CompletedTask;
        }

        public Task Handle(TagStatusChanged e)
        {
           TagViewModel tagViewModel= dbContext.TagViewModels.Find(e.Id); 
            if(tagViewModel ==null)
                throw new Exception("Team is not found!!!");
            tagViewModel.IsActive = e.Status;

            return Task.CompletedTask;
        }
    }
}
