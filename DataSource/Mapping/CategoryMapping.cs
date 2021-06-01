using DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Mapping
{
    public class CategoryMapping : AggregateRootTypeConfig<Category>
    {
        protected override void Config(EntityTypeBuilder<Category> builder)
        {
            
        }
    }
}
