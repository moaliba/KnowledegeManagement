using CommandHandling.Abstractions;
using System;

namespace UseCases.Commands.Post
{
    public record PostCommand(Guid Id, string PostTitle, string PostContent, Guid CategoryId, Guid UserId, string Tags) : Acommand(Id)
    {
        public static PostCommand Create(Guid Id, string PostTitle, string PostContent, Guid CategoryId, Guid UserId, string Tags)
        {
            if (PostTitle.Trim().Length == 0)
                throw new Exception("PostTitle must be not null and empty.");
            if (PostContent.Trim().Length == 0)
                throw new Exception("PostContent must be not null and empthy.");
            return new PostCommand(Id, PostTitle, PostContent, CategoryId, UserId, Tags);
        }
    }
}
