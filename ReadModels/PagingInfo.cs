using System;

namespace ReadModels
{
    public class PagingInfo
    {

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPageCount { get; }

        public PagingInfo(int number,int size,int totalCount)
        {
            PageNumber = number;
            PageSize = size;
            TotalCount = totalCount;
            TotalPageCount = (int)Math.Ceiling(totalCount / (double)size);
        }
    }
}