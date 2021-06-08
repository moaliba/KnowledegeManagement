using QueryHandling.Abstractions;
using System.Collections.Generic;

namespace ReadModels.ViewModel.Tag
{
    public class TagViewModelList : IAmAViewModel
    {
        public IEnumerable<TagViewModel> TagViewModels { get; set; }

        public int TotalCount { get; set; }
    }
}
