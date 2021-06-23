using DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataSource.Mapping
{
    public class PostAttachmentMapping 
    {
        protected void Config(EntityTypeBuilder<PostAttachment> builder)
        {
            builder.Ignore(c => c.File);
        }
    }
}
