using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI.DTOs
{
    public class ChangeTagPropertiesDTO
    {
        public string Title { get; set; }
        public Guid? CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
