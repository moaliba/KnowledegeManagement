using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;

namespace UseCases.Commands.PostAttachment
{
    public record PostAttachmentFileDataStructure(Guid Id, string Title, IFormFile File)
    {
        public static PostAttachmentFileDataStructure Create(Guid Id, string Title, IFormFile File)
        {
            if (string.IsNullOrWhiteSpace(Title))
                throw new ArgumentNullException(nameof(Title));

            if (File == null)
                throw new ArgumentNullException(nameof(File));

            if (File.Length == 0)
                throw new ArgumentNullException(nameof(File));

            string filename = ContentDispositionHeaderValue.Parse(File.ContentDisposition).FileName.ToString().Trim('"');

            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException(nameof(filename));
            return new(Id, Title, File);
        }
    }
}
