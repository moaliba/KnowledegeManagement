using QueryHandling.Abstractions;
using ReadModels.Query.PostAttachment;
using ReadModels.ViewModel;
using ReadModels.ViewModel.PostAttachment;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.PostAttachment
{
    public class GetPostAllAttachmentsQueryHandler : IHandleQuery<GetPostAllAttachmentsQuery, PagedViewModel<UserPostAttachmentViewModel>>
    {
        private readonly IReadDbContext dbContext;
        public GetPostAllAttachmentsQueryHandler(IReadDbContext readDbContext)
        {
            this.dbContext = readDbContext;
        }

        public Task<PagedViewModel<UserPostAttachmentViewModel>> Handle(GetPostAllAttachmentsQuery query)
        {
            var UserPostAttachmentViewModel = dbContext.PostAttachmentViewModels.Where(c => c.PostId == query.PostId).Select(c => new UserPostAttachmentViewModel()
            {
                FileName = c.FileName,
                PostAttachmentId = c.PostAttachmentId,
                PostAttachmentTitle = c.PostAttachmentTitle
            });
            var result = PagingUtility.Paginate(query.PageNumber, query.PageSize, UserPostAttachmentViewModel);
            return Task.FromResult(result);
        }
    }
}
