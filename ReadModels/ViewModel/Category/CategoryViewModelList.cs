using QueryHandling.Abstractions;
using System.Collections.Generic;

namespace ReadModels.ViewModel
{
    public class CategoryViewModelList:IAmAViewModel
    {
        public IEnumerable<CategoryViewModel> CategoryViewModels { get; set; }

        public int TotalCount { get; set; }
    }
}
