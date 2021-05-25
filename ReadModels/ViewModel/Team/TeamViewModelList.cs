using QueryHandling.Abstractions;
using System.Collections.Generic;

namespace ReadModels.ViewModel.Team
{
    public class TeamViewModelList : IAmAViewModel
    {
        public IEnumerable<TeamViewModel> TeamViewModels { get; set; }

        public int TotalCount { get; set; }
    }
}
