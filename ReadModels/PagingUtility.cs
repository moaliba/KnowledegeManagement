using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels
{
    public class PagingUtility<T>
    {
        public static PagedViewModel<T> Paginate(int pageNumber,int pageSize, IQueryable<T> allItems)
        {
            var counter = new PageCounter(pageNumber
                               , pageSize
                               , allItems?.Count() ?? 0);

            var vm = new PagedViewModel<T>(counter, allItems);
            return vm;
        }
    }
}
