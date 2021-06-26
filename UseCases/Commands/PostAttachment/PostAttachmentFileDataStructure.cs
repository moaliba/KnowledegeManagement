using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;
using UseCases.Exceptions;

namespace UseCases.Commands.PostAttachment
{
    public record PostAttachmentFileDataStructure(Guid Id, string Title, IFormFile File)
    {
        public static PostAttachmentFileDataStructure Create(Guid Id, string Title, IFormFile File)
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
            return new(Id, Title, File);
        }
    }
}
