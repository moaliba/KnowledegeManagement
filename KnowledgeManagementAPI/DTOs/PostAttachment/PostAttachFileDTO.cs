using KnowledgeManagementAPI.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.PostAttachment
{
    public class PostAttachFileDTO
    {
        [Description("عنوان پیوست")]
        public string Title { get; set; }

        [Description("فایل پیوست")]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions]
        public IFormFile File { get; set; }
    }
}
