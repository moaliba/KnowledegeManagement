
namespace KnowledgeManagementAPI.DTOs
{
    public abstract class FilterModelBase  // : ICloneable  using for generating next and previous url
    {
        const int maxPageSize = 200;
        public int PageNumber { get; set; } = 1;
        private int? _pageSize;
        public int PageSize
        {
            get
            {
                return _pageSize??0;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string SortOrder { get; set; }

       // public FilterModelBase() => SortOrder = !string.IsNullOrEmpty(SortOrder) ? SortOrder.ToLower() : string.Empty;
    }
}
