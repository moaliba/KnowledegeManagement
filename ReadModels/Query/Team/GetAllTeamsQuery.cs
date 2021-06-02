using QueryHandling.Abstractions;
using ReadModels.ViewModel.Team;
using System;

namespace ReadModels.Query.Team
{
    public record GetAllTeamsQuery(Guid Id,int PageNumber, int PageSize,string Title,string SortOrder) : Query<TeamViewModelList>;
}
