using DomainModel;
using Microsoft.EntityFrameworkCore;
using ReadModels.DomainModel.Document;

namespace DataAccess
{
    public interface IWriteDbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostAttachment> PostAttachments { get; set; }
        public DbSet<DocumentView> DocumentView { get; set; }
    }
}
