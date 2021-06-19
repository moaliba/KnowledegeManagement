
namespace KnowledgeManagementAPI.DTOs.Category
{
    public class GetCategoryListDTO : FilterModelBase
    {
        public string CategoryTitle { get; set; }

        public bool? IsActive { get; set; }
    }
}
