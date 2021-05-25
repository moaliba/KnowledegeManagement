using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI.DTOs
{
    public abstract class FilterModelBase  // : ICloneable  using for generating next and previous url
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string SortOrder { get; set; }

        public FilterModelBase()
        {
            this.PageNumber = 1;
            this.PageSize = 20;
        }
    }
}
