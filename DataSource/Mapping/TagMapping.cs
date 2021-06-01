using DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Mapping
{
    class TagMapping : AggregateRootTypeConfig<Tag>
    {
        protected override void Config(EntityTypeBuilder<Tag> builder)
        {
        }
    }
}
