using System;
using System.ComponentModel;

namespace KnowledgeManagementAPI.DTOs.PostAttachment
{
    public class GetPostAttachmentListDTO: FilterModelBase
    {
        [Description("شناسه پست")]
        public Guid PostId { get; set; }
    }
}
