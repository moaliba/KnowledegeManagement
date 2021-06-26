using CommandHandling.Abstractions;
using System;
using System.Collections.Generic;
using UseCases.Commands.PostAttachment;
using UseCases.Exceptions;

namespace UseCases.Commands.Post
{
    public record PostCommand(Guid Id, string PostTitle, string PostContent, Guid CategoryId, Guid UserId,
        string Tags, List<PostAttachmentFileDataStructure> AttachmentList) : Acommand(Id)
    {
        public static PostCommand Create(Guid Id, string PostTitle, string PostContent, Guid CategoryId, Guid UserId,
            string Tags, List<PostAttachmentFileDataStructure> AttachmentList)
        {
            if (PostTitle.Trim().Length == 0)
                throw new BadRequestException("PostTitle must be not null and empty.");
            if (PostContent.Trim().Length == 0)
                throw new BadRequestException("PostContent must be not null and empthy.");
            return new PostCommand(Id, PostTitle, PostContent, CategoryId, UserId, Tags, AttachmentList);
        }
    }
}
