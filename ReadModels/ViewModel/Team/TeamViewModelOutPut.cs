using QueryHandling.Abstractions;
using System.Collections.Generic;

namespace ReadModels.ViewModel.Team
{
    public class TeamViewModelOutPut : IAmAViewModel
    {
        public IEnumerable<TeamViewModel> TeamViewModels { get; set; }
    }
}
