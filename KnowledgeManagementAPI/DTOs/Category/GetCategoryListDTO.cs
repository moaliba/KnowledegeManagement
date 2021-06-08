
namespace KnowledgeManagementAPI.DTOs.Category
{
    public class GetCategoryListDTO : FilterModelBase
    {
        public string CategoryTitle { get; set; }

        public GetCategoryListDTO() : base()
        => PageSize = 10;
    }
}
