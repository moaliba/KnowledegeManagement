using QueryHandling.Abstractions;
using ReadModels.ViewModel.Tag;
using ReadModels.ViewModel.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.Query.Tag
{
    public record  GetTagQuery(Guid Id) : Query<TagViewModel>;
    
}
