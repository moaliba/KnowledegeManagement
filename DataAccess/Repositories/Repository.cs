
namespace DataAccess.Repositories
{
    public class Repository
    {
        protected readonly IWriteDBContext dbContext;

        public Repository(IWriteDBContext DBContex)
         => dbContext = DBContex;

        public void SaveChanges()
        {
            
        }
    }
}
