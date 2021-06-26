using System;
using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.Category
{
    public class CategoryChangeStatusDTO
    {
        [Description("وضعیت")]
        public bool IsActive { get; set; }
    }
}
