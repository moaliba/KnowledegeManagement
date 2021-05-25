using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI
{
    public class PagedResponse<T>
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }

        public PagedResponse()
        {

        }

        public PagedResponse(T data,int totalCount)
        {
            Data = data;
            TotalCount = totalCount;

        }
    }
}
