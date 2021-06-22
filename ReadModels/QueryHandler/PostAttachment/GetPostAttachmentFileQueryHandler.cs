using Microsoft.EntityFrameworkCore;
using QueryHandling.Abstractions;
using ReadModels.DomainModel.Document;
using ReadModels.Query.PostAttachment;
using ReadModels.ViewModel.PostAttachment;
using System;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModels.QueryHandler.PostAttachment
{
    public class GetPostAttachmentFileQueryHandler : IHandleQuery<GetPostAttachmentFileQuery, PostAttachmentFileViewModel>
    {
        private readonly IReadDbContext readDbContext;
        public GetPostAttachmentFileQueryHandler(IReadDbContext readDbContext)
        => this.readDbContext = readDbContext;

        public Task<PostAttachmentFileViewModel> Handle(GetPostAttachmentFileQuery query)
        {
            PostAttachmentViewModel File = readDbContext.PostAttachmentViewModels
                .FirstOrDefault(c => c.PostAttachmentId == query.PostAttachmentId);

            if (File == null)
                throw new Exception("FileAttachment does not exist!!!");
            SqlParameter param1 = new("path_locator", System.Data.SqlDbType.VarChar, 4000) { Value = File.FilePath };
            DocumentView d = readDbContext.DocumentView.Where(c => c.path_locator == File.FilePath).FirstOrDefault();
                                //.FromSqlRaw("EXECUTE dbo.GetDocument @path_locator", param1)
                                //.AsEnumerable().FirstOrDefault();
            PostAttachmentFileViewModel result = new()
            {
                PostAttachmentId = query.PostAttachmentId,
                File = d.file_stream
            };
            return Task.FromResult(result);
        }
    }
}
