
namespace DataAccess.Repositories
{
    public class Repository
    {
        protected readonly IWriteDbContext dbContext;

        public Repository(IWriteDbContext DBContex)
         => dbContext = DBContex;

        public void SaveChanges()
        {
            
        }
    }
}
