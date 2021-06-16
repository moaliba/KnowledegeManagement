using KnowledgeManagementAPI.Filters;
using Microsoft.AspNetCore.Http;
using System;

namespace KnowledgeManagementAPI.DTOs.PostAttachment
{
    public class PostAttachFileDTO
    {
        public string Title { get; set; }

        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions]
        public IFormFile File { get; set; }
    }
}
