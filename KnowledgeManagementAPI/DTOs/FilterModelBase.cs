
namespace KnowledgeManagementAPI.DTOs
{
    public abstract class FilterModelBase  // : ICloneable  using for generating next and previous url
    {
        const int maxPageSize = 200;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 20;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string SortOrder { get; set; }

        //public FilterModelBase()
        //{
        //    this.PageNumber = 1;
        //    this.PageSize = 20;
        //}
    }
}
