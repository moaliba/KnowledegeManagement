using QueryHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadModels.ViewModel
{
    public  class PagedViewModel<T> : IAmAViewModel
    {
        public PagingInfo PagingInfo { get; }
        public IEnumerable<T> Data { get; }

        //public IQueryable<T> ItemsInThePage { get; }

        public PagedViewModel(PagingInfo info, IQueryable<T> allItems)
        {

                PagingInfo = info ?? throw new ArgumentNullException(nameof(info));
                Data = null == allItems
                               ? Array.Empty<T>().AsEnumerable()
                               : SlicePage(allItems, PagingInfo).AsEnumerable();

               
        }

        IQueryable<T> SlicePage(IQueryable<T> allItems, PagingInfo page)
        {
            if (page.PageSize == 0)
                return allItems;
           return allItems.Skip((int)(page.PageSize * (page.PageNumber - 1))).Take(page.PageSize);
        }
    }
}
