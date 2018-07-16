using SMSApp.DataAccess;
using SMSApp.Repositories;
using SMSApp.Repositories.Core;

namespace SMSApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public static UnitOfWork Instance { get; private set; }

        private readonly Context AppContext;

        public UnitOfWork(Context appContext)
        {
            AppContext = appContext;
            Users = new UserRepository(appContext);
            Instance = this;
        }

        public IUserRepository Users { get; private set; }

        public IBroadcastRepository Broadcasts => throw new System.NotImplementedException();

        public IContagionRepository Contagions => throw new System.NotImplementedException();

        public IDiseaseRepository Diseases => throw new System.NotImplementedException();

        public IFarmRepository Farms => throw new System.NotImplementedException();

        public IFarmPlantRepository FarmOwners => throw new System.NotImplementedException();

        public IGeopositionRepository Geopositions => throw new System.NotImplementedException();

        public IMessageRepository Messages => throw new System.NotImplementedException();

        public IPestRepository Pests => throw new System.NotImplementedException();

        public IPhotoRepository Photos => throw new System.NotImplementedException();

        public IPlantRepository Plants => throw new System.NotImplementedException();

        public ISoilReadingRepository SoilReadings => throw new System.NotImplementedException();

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
