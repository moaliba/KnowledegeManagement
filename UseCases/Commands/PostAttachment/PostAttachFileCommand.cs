using CommandHandling.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;
using UseCases.Exceptions;

namespace UseCases.Commands.PostAttachment
{
    public record PostAttachFileCommand(Guid id, string Title, Guid PostId, Guid UserId, IFormFile File) : Acommand(id)
    {
        public static PostAttachFileCommand Create(Guid id, string Title, Guid PostId, Guid UserId, IFormFile File)
        {
            if (string.IsNullOrWhiteSpace(Title))
                throw new BadRequestException("Title must be not null and empty!!!");

            if (File == null)
                throw new BadRequestException("File must be not null and empty!!!");

            if (File.Length == 0)
                throw new BadRequestException("File must be not null and empty!!!");

            string filename = ContentDispositionHeaderValue.Parse(File.ContentDisposition).FileName.ToString().Trim('"');

            if (string.IsNullOrWhiteSpace(filename))
                throw new BadRequestException("FileName must be not null and empty!!!");

            return new PostAttachFileCommand(id, Title, PostId, UserId, File);
        }
    }
}
