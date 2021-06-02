using QueryHandling.Abstractions;
using ReadModels.Query.Tag;
using ReadModels.ViewModel.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.TagQueryHandler
{
    public class GetTagQueryHandler : IHandleQuery<GetTagQuery, TagViewModel>
    {
        readonly IReadDbContext dbContext;
        public GetTagQueryHandler(IReadDbContext dbContext)
        => this.dbContext = dbContext;

        public  Task<TagViewModel> Handle(GetTagQuery query)
        {
            TagViewModel tag = dbContext.TagViewModels.Find(query.Id);
            if (tag != null)
                return Task.FromResult(tag);
            throw new Exception("Team is not found!!!");
        }
    }
}
