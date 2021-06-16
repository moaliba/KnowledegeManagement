using QueryHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels.ViewModel
{
    public class ListViewModel<T> : IAmAViewModel
    {
        public IEnumerable<T> Data { get; set; }
    }
}
