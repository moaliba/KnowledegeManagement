using DomainModel;
using System;

namespace UseCases.RepositoryContracts
{
    public interface IPostRepository
    {
        public void Add(Post post);

        public Post Find(Guid Id);
    }
}
