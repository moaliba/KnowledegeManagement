using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.RepositoryContracts
{
    public interface ITagRepository
    {
        void Add(Tag tag);
        bool DoesExistInCategory(string title,Guid? categoryId);
        void Update(Tag tag);
        Tag Find(Guid id);
    }
}
