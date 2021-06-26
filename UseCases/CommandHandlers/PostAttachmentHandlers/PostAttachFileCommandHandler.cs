using CommandHandling.Abstractions;
using DomainModel;
using System;
using System.IO;
using System.Threading.Tasks;
using UseCases.Commands.PostAttachment;
using UseCases.Exceptions;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.PostAttachmentHandlers
{
    public class PostAttachFileCommandHandler : IHandleCommand<PostAttachFileCommand>
    {
        private readonly IPostAttachmentRepository postAttachments;
        private readonly IPostRepository posts;
        public PostAttachFileCommandHandler(IPostAttachmentRepository postAttachments, IPostRepository posts)
        {
            this.postAttachments = postAttachments;
            this.posts = posts;
        }

        public Task Handle(PostAttachFileCommand command)
        {
            Post post = posts.Find(command.PostId);
            if (post == null)
                throw new NotFoundException("Selected post does not exist!!!");

            if (command.UserId != post.UserId)
                throw new Exception("User is not allowed to attach file!!!");
            using (Stream stream = command.File.OpenReadStream())
            {
                BinaryReader reader = new BinaryReader(stream);
                byte[] file = reader.ReadBytes(Convert.ToInt32(command.File.Length));
                string fileName = command.File.FileName;
                long fileSize = command.File.Length;
                string fileExtention = Path.GetExtension(command.File.FileName);

                postAttachments.Add(PostAttachment.AttachFile(command.id, command.Title, command.PostId,
                    command.UserId, fileName, fileExtention, fileSize, string.Empty, file));
            }
            return Task.CompletedTask;
        }
    }
}
