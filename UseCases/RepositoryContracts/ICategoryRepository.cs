using DomainModel;
using System;

namespace UseCases.RepositoryContracts
{
    public interface ICategoryRepository
    {
        void Create(Category category);

        bool DeosExist(string title);

        void Update(Category category);

        Category Find(Guid Id);
    }
}
