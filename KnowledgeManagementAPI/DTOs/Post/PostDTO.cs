using KnowledgeManagementAPI.DTOs.PostAttachment;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.Post
{
    public class PostDTO
    {
        [Description("شناسه دسته بندی")]
        public Guid CategoryId { get; set; }

        [Description("شناسه کاربر")]
        public Guid UserID { get; set; }

        [Description("عنوان پست")]
        public string PostTitle { get; set; }

        [Description("محتوای پست")]
        public string PostContent { get; set; }

        [Description("برچسب ها")]
        public string Tags { get; set; }

        [Description("پیوست ها")]
        public List<PostAttachFileDTO> FileList { get; set; }
    }
}
