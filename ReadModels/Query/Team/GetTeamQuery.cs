using QueryHandling.Abstractions;
using ReadModels.ViewModel.Team;
using System;

namespace ReadModels.Query.Team
{
    public record GetTeamQuery(Guid TeamId) : Query<TeamViewModel>;
    
}
