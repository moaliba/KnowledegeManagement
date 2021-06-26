using CommandHandling.Abstractions;
using DomainModel;
using System;
using System.IO;
using System.Threading.Tasks;
using UseCases.Commands.Post;
using UseCases.Commands.PostAttachment;
using UseCases.Exceptions;
using UseCases.RepositoryContracts;

namespace UseCases.CommandHandlers.PostHandlers
{
    public class PostHandler : IHandleCommand<PostCommand>
    {
        private readonly IPostRepository posts;
        private readonly ICategoryRepository Categories;
        public PostHandler(IPostRepository posts, ICategoryRepository Categories)
        {
            this.posts = posts;
            this.Categories = Categories;
        }

        public Task Handle(PostCommand command)
        {
            if (Categories.Find(command.CategoryId) == null)
                throw new NotFoundException("Category does not exist!!");

            Post post = Post.DefinePost(command.Id, command.PostTitle, command.PostContent, command.CategoryId, command.UserId, command.Tags);
            foreach (PostAttachmentFileDataStructure File in command.AttachmentList)
            {
                using (Stream stream = File.File.OpenReadStream())
                {
                    BinaryReader reader = new BinaryReader(stream);
                    byte[] file = reader.ReadBytes(Convert.ToInt32(File.File.Length));
                    string fileName = File.File.FileName;
                    long fileSize = File.File.Length;
                    string fileExtention = Path.GetExtension(File.File.FileName);

                    post.AttachFile(File.Id, File.Title, command.Id,
                        command.UserId, fileName, fileExtention, fileSize, string.Empty, file);
                }
            }
            posts.Add(post);
            return Task.CompletedTask;
        }
    }
}
