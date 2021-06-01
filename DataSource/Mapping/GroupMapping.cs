using DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataSource.Mapping
{
    public class GroupMapping : AggregateRootTypeConfig<Group>
    {
        protected override void Config(EntityTypeBuilder<Group> builder)
        {
        }
    }
}
