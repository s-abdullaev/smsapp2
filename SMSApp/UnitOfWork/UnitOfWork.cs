using SMSApp.Core.Repositories;
using SMSApp.DataAccess;

namespace SMSApp
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork Instance { get; private set; }

        private readonly AppContext AppContext;

        public UnitOfWork(AppContext appContext)
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
