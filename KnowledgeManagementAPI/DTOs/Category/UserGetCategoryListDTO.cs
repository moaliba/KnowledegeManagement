using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.Category
{
    public class UserGetCategoryListDTO : FilterModelBase
    {
        [Description("عنوان دسته بندی")]
        public string CategoryTitle { get; set; }
    }
}
