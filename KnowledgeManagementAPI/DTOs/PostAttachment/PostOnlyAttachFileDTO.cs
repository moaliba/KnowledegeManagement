using KnowledgeManagementAPI.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.PostAttachment
{
    public class PostOnlyAttachFileDTO
    {
        [Description("عنوان پیوست")]
        public string Title { get; set; }

        [Description("شناسه پست")]
        public Guid PostId { get; set; }

        [Description("شناسه کاربر")]
        public Guid UserId { get; set; }

        [Description("فایل پیوست")]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions]
        public IFormFile File { get; set; }
    }
}
