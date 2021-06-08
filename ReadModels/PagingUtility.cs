using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModels
{
    public class PagingUtility
    {
        public static PagedViewModel<T> Paginate<T>(int pageNumber,int pageSize, IQueryable<T> allItems)
        {
            var info = new PagingInfo(pageNumber
                               , pageSize
                               , allItems?.Count() ?? 0);

            var vm = new PagedViewModel<T>(info, allItems);
            return vm;
        }
    }
}
