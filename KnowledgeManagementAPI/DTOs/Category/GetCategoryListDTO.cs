
using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.Category
{
    public class GetCategoryListDTO : FilterModelBase
    {
        [Description("عنوان دسته بندی")]
        public string CategoryTitle { get; set; }

        [Description("وضعیت")]
        public bool? IsActive { get; set; }
    }
}
