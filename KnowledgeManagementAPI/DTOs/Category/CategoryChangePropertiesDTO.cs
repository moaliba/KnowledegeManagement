using System;
using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.Category
{
    public class CategoryChangePropertiesDTO
    {
        [Description("عنوان دسته بندی")]
        public string Title { get; set; }

        [Description("فعال")]
        public bool IsActive { get; set; }
    }
}
