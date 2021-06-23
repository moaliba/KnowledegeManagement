using QueryHandling.Abstractions;
using ReadModels.Query.Post;
using ReadModels.ViewModel.Post;
using ReadModels.ViewModel.PostAttachment;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.Post
{
    public class GetPostQueryHandler : IHandleQuery<GetPostQuery, PostWithAttachmentViewModel>
    {
        private readonly IReadDbContext dbContext;
        public GetPostQueryHandler(IReadDbContext readDbContext)
        => dbContext = readDbContext;

        public Task<PostWithAttachmentViewModel> Handle(GetPostQuery query)
        {
            PostWithAttachmentViewModel result = new();
            PostViewModel post = dbContext.PostViewModels.FirstOrDefault(c => c.PostId == query.Id);
            if (post != null)
            {
                result.PostViewModel = post;
                List<PostAttachmentViewModel> FileAttachments = dbContext.PostAttachmentViewModels.Where(c => c.PostId == query.Id).ToList();
                result.FileAttachments = FileAttachments;
            }
            return Task.FromResult(result);
        }
    }
}
