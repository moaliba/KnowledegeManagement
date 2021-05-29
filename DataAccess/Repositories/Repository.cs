

namespace DataAccess.Repositories
{
    public class Repository
    {
        protected readonly IWriteDBContext _dbContex;

        public Repository(IWriteDBContext DBContex)
         => _dbContex = DBContex;

        public void SaveChanges()
        {
            
        }
    }
}
