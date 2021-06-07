using QueryHandling.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadModels
{
    public  class PagedViewModel<T> : IAmAViewModel
    {
        public PageCounter Counter { get; }
        public IQueryable<T> ItemsInThePage { get; }
        public IEnumerable<T> Data { get; }
        public PagedViewModel(PageCounter counter, IQueryable<T> allItems)
        {
            Counter = counter ?? throw new ArgumentNullException(nameof(counter));

            Data = null == allItems
                           ? Array.Empty<T>().AsEnumerable()
                           : SlicePage(allItems, Counter).AsEnumerable();
        }

        IQueryable<T> SlicePage(IQueryable<T> allItems, PageCounter page)
        => allItems.Skip((int)(page.Size * (page.Number - 1))).Take(page.Size);
    }
}
