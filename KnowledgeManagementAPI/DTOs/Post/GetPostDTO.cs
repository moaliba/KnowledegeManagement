using System;

namespace KnowledgeManagementAPI.DTOs.Post
{
    public class GetPostDTO: FilterModelBase
    {
        public string PostTitle { get; set; }

        public Guid? CategoryID { get; set; }

        public string Tags { get; set; }
    }
}
