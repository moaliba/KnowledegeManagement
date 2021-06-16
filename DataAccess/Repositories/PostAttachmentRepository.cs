using DomainModel;
using EventHandling.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using UseCases.RepositoryContracts;

namespace DataAccess.Repositories
{
    public class PostAttachmentRepository : Repository, IPostAttachmentRepository
    {
        private readonly IEventBus eventBus;
        public PostAttachmentRepository(IWriteDbContext dbContext, IEventBus eventBus) : base(dbContext)
        => this.eventBus = eventBus;

        public void Add(PostAttachment postAttachment)
        {
            SqlParameter relativePath = new("relativePath", System.Data.SqlDbType.VarChar, 255) { Value = DBNull.Value };
            SqlParameter fileName = new("name", System.Data.SqlDbType.VarChar, 255) { Value = postAttachment.FileSystemName };
            SqlParameter file = new("stream", System.Data.SqlDbType.VarBinary) { Value = postAttachment.File };
            SqlParameter filePath = new()
            {
                ParameterName = "path_locator",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 4000,
                Direction = System.Data.ParameterDirection.Output,
            };

            dbContext.DocumentView
                    .FromSqlRaw("EXECUTE dbo.AddDocument @relativePath,@name,@stream,@path_locator", relativePath, fileName, file, filePath)
                    .AsEnumerable().FirstOrDefault();

            postAttachment.AddFilePath(Convert.ToString(filePath.Value));
            foreach (AnEvent @event in postAttachment.Events)
            {
                eventBus.Publish(@event);
            }
            postAttachment.ClearEvents();
            dbContext.PostAttachments.Add(postAttachment);
        }
    }
}