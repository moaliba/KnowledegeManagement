using System;
using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.Post
{
    public class GetPostDTO: FilterModelBase
    {
        [Description("عنوان پست")]
        public string PostTitle { get; set; }

        [Description("شناسه دسته بندی")]
        public Guid? CategoryID { get; set; }

        [Description("برچسب ها")]
        public string Tags { get; set; }
    }
}
