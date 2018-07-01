using SMSApp.DataAccess;
using SMSApp.Repositories;
using SMSApp.Repositories.Core;

namespace SMSApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork Instance { get; private set; }

        private readonly Context AppContext;

        public UnitOfWork(Context appContext)
        {
            AppContext = appContext;
            Users = new UserRepository(appContext);
            Instance = this;
        }

        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return AppContext.SaveChanges();
        }

        public void Dispose()
        {
            AppContext.Dispose();
        }
    }
}
