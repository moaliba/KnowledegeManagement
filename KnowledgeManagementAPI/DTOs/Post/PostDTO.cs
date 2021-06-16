using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeManagementAPI.DTOs.Post
{
    public class PostDTO 
    {
        public Guid CategoryId { get; set; }

        public Guid UserID { get; set; }

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public string Tags { get; set; }
    }
}
