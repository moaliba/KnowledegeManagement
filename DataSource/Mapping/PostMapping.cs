using DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataSource.Mapping
{
    public class PostMapping : AggregateRootTypeConfig<Post>
    {
        protected override void Config(EntityTypeBuilder<Post> builder)
        {
            
        }
    }
}
