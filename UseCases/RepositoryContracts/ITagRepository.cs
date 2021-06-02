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
        bool DoesExist(string title,Guid? categoryId);
    }
}
