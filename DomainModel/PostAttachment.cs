using DomainEvents.PostAttachment;
using System;

namespace DomainModel
{
    public class PostAttachment : AggregateRoot
    {
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
        => RecordThat(new PostFileAdded(Id, Title, PostId, UserId, FileName, FileType, FileSystemName, FileSize, filePath, File));

        public PostAttachment(Guid id, string Title, Guid PostId, Guid UserId, string FileName, string FileType, string FileSystemName,
            long FileSize, string FilePath, byte[] File) : base(id)
        => RecordThat(new PostFileAttached(id, Title, PostId, UserId, FileName, FileType, FileSystemName, FileSize, FilePath, File));

        void On(PostFileAttached e)
        {
            Title = e.Title;
            FileName = e.FileName;
            FilePath = e.FilePath;
            FileSize = e.FileSize;
            PostId = e.PostId;
            UserId = e.UserId;
            FileSystemName = e.FileSystemName;
            FileType = e.FileType;
            File = e.File;
        }

        void On(PostFileAdded e)
        => FilePath = e.FilePath;
    }
}