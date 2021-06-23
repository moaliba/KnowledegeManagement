using DomainEvents.PostAttachment;
using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class PostAttachment
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; private set; }

        public Guid PostId { get; private set; }

        public Guid UserId { get; private set; }

        public string FileSystemName { get; private set; }

        public string FileName { get; private set; }

        public string FileType { get; private set; }

        public long FileSize { get; private set; }

        public string FilePath { get; private set; }

        public byte[] File { get; private set; }

        public static PostAttachment AttachFile(Guid id, string Title, Guid PostId, Guid UserId, string FileName, string FileType,
            long FileSize, string FilePath, byte[] File)
        => new(id, Title, PostId, UserId, FileName, FileType, FileSystemName: MakeFileSystemName(FileName), FileSize, FilePath, File);

        private static string MakeFileSystemName(string FileName)
        => Guid.NewGuid().ToString() + FileName;

        [Obsolete]
        public PostAttachment()
        {
        }

        public void AddFilePath(string filePath)
        => FilePath = filePath;

        public PostAttachment(Guid Id, string Title, Guid PostId, Guid UserId, string FileName, string FileType, string FileSystemName,
            long FileSize, string FilePath, byte[] File)
        {
            this.Id = Id;
            this.Title = Title;
            this.FileName = FileName;
            this.FilePath = FilePath;
            this.FileSize = FileSize;
            this.PostId = PostId;
            this.UserId = UserId;
            this.FileSystemName = FileSystemName;
            this.FileType = FileType;
            this.File = File;
        }
    }
}