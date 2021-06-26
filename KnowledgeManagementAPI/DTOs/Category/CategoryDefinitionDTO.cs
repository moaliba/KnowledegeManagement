using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.Category
{
    public class CategoryDefinitionDTO
    {
        [Description("عنوان دسته بندی")]
        public string Title { get; set; }

        [Description("وضعیت")]
        public bool IsActive { get; set; }
    }
}
