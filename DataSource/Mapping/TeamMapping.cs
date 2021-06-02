using DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataSource.Mapping
{
    public class TeamMapping : AggregateRootTypeConfig<Team>
    {
        protected override void Config(EntityTypeBuilder<Team> builder)
        {
          //  builder.HasKey(p => p.TeamId);
        }
    }
}
