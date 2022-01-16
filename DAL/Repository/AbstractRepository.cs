using System;
using EntityDataBase;

namespace DAL.Repository
{
    public class AbstractRepository : IDisposable
    {
        protected ShopContext applicationContext;
        public AbstractRepository()
        {
            applicationContext = new ShopContext();
        }
        public void Dispose()
        {
            applicationContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
