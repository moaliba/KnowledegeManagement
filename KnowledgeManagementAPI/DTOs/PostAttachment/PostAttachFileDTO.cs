﻿using KnowledgeManagementAPI.Filters;
using Microsoft.AspNetCore.Http;
using System;

namespace KnowledgeManagementAPI.DTOs.PostAttachment
{
    public class PostAttachFileDTO
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions]
        public IFormFile File { get; set; }
    }
}
