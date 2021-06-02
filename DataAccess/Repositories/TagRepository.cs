using DomainModel;
using System;
using System.Linq;
using UseCases.RepositoryContracts;

namespace DataAccess.Repositories
{
    public class TagRepository : Repository, ITagRepository
    {
        public TagRepository(IWriteDbContext dbContext ) :base(dbContext)
        {

        }
        public void Add(Tag tag)
        {

            dbContext.Tags.Add(tag);
        }

        public bool DoesExist(string title, Guid categoryId)
        => dbContext.Tags.FirstOrDefault(t => t.Title == title && t.CategoryId==categoryId) != null;

        public bool DoesExist(string title)
        {
            throw new NotImplementedException();
        }
    }
}
