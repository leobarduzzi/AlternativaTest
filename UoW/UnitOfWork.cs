using AlternativaTest.Data;

namespace AlternativaTest.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext _db;

        public UnitOfWork(AppDataContext db)
        {
            this._db = db;
        }
        
        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}