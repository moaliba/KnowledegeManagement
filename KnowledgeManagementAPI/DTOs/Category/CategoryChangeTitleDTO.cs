using System;
using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.Category
{
    public class CategoryChangeTitleDTO
    {
        [Description("عنوان دسته بندی")]
        public string Title { get; set; }

        [Description("شناسه دسته بندی")]
        public Guid CategoryId { get; set; }
    }
}
