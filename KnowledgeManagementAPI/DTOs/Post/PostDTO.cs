using KnowledgeManagementAPI.DTOs.PostAttachment;
using System;
using System.Collections.Generic;

namespace KnowledgeManagementAPI.DTOs.Post
{
    public class PostDTO 
    {
        public Guid CategoryId { get; set; }

        public Guid UserID { get; set; }

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public string Tags { get; set; }

        public List<PostAttachFileDTO> FileList { get; set; }
    }
}
