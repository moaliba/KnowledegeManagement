using DomainEvents.Tag;
using EventHandling.Abstractions;
using ReadModels.ViewModel.Tag;
using System;
using System.Threading.Tasks;

namespace ReadModels.Projectors
{
    public class TagListProjector : IHandleEvent<TagDefined>
    {
        readonly IReadDbContext dbContext;

        public TagListProjector(IReadDbContext dbContex)
        => this.dbContext = dbContex;
       
        public Task Handle(TagDefined e)
        {
            string CategoryName = "";

            dbContext.TagViewModels.Add(new TagViewModel
            {
                Id = e.Id,
                Title=e.Title,
                CategoryName= CategoryName,
                UserId=Guid.NewGuid()
            });

            return Task.CompletedTask;
        }
    }
}
