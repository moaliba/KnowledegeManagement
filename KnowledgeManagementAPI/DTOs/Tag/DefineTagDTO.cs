using System;

namespace KnowledgeManagementAPI.DTOs
{
    public class DefineTagDTO
    {
        public string Title { get; set; }
        public Guid? CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
