using QueryHandling.Abstractions;
using ReadModels.ViewModel.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.Query.Team
{
    public record GetTeamQuery(Guid TeamId) : Query<TeamViewModel>;
    
}
