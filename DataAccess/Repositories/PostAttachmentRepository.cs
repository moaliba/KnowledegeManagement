using DomainModel;
using EventHandling.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Data.SqlClient;
using System.Linq;
using UseCases.RepositoryContracts;

namespace DataAccess.Repositories
{
    public class PostAttachmentRepository : Repository, IPostAttachmentRepository
    {
        private readonly IEventBus eventBus;
        public PostAttachmentRepository(IWriteDbContext dbContext, IEventBus eventBus) : base(dbContext)
        => this.eventBus = eventBus;

        public string Add(PostAttachment postAttachment)
        {
            SqlParameter relativePath = new("relativePath", System.Data.SqlDbType.NVarChar, 255) { Value = DBNull.Value };
            SqlParameter fileName = new("name", System.Data.SqlDbType.NVarChar, 255) { Value = postAttachment.FileSystemName };
            SqlParameter file = new("stream", System.Data.SqlDbType.VarBinary) { Value = postAttachment.File };
            SqlParameter filePath = new SqlParameter("path_locator", System.Data.SqlDbType.NVarChar, 4000) { Value = DBNull.Value };
            string FilePath = dbContext.DocumentView
                    .FromSqlRaw("EXECUTE dbo.AddDocument @relativePath,@name,@stream,@path_locator", relativePath, fileName, file, filePath)
                    .AsEnumerable().FirstOrDefault().path_locator;

            postAttachment.AddFilePath(FilePath);
            //foreach (AnEvent @event in postAttachment.Events)
            //{
            //    eventBus.Publish(@event);
            //}
            //postAttachment.ClearEvents();
            dbContext.PostAttachments.Add(postAttachment);
            return FilePath;
        }
    }
}