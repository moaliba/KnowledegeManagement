using QueryHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.ViewModel.Tag
{
    public class TagViewModelList : IAmAViewModel
    {
        public IEnumerable<TagViewModel> TagViewModels { get; set; }

        public int TotalCount { get; set; }
    }
}
