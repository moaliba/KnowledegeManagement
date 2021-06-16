using DomainModel;

namespace UseCases.RepositoryContracts
{
    public interface IPostAttachmentRepository
    {
        public void Add(PostAttachment postAttachment);
    }
}
