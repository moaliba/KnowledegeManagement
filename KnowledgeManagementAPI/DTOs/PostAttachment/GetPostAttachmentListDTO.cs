using System;

namespace KnowledgeManagementAPI.DTOs.PostAttachment
{
    public class GetPostAttachmentListDTO: FilterModelBase
    {
        public Guid PostId { get; set; }
    }
}
