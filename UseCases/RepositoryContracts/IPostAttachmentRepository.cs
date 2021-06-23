using DomainModel;

namespace UseCases.RepositoryContracts
{
    public interface IPostAttachmentRepository
    {
        public string Add(PostAttachment postAttachment);
    }
}
