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
            FarmOwners = new FarmOwnerRepository(appContext);
            Broadcasts = new BroadcastRepository(appContext);
            Contagions = new ContagionRepository(appContext);
            Diseases = new DiseaseRepository(appContext);
            Farms = new FarmRepository(appContext);
            Geopositions = new GeopositionRepository(appContext);
            Messages = new MessageRepository(appContext);
            Pests = new PestRepository(appContext);
            Photos = new PhotoRepository(appContext);
            Plants = new PlantRepository(appContext);
            SoilReadings = new SoilReadingRepository(appContext);
            Instance = this;
        }

        public IRepository<T> GetRepository<T>(string repoName) where T : class
        {
            return (IRepository<T>)GetType().GetProperty(repoName).GetValue(this);
        }

        public IUserRepository Users { get; private set; }

        public IBroadcastRepository Broadcasts { get; private set; }

        public IContagionRepository Contagions { get; private set; }

        public IDiseaseRepository Diseases { get; private set; }

        public IFarmRepository Farms { get; private set; }

        public IFarmOwnerRepository FarmOwners { set; get; }

        public IGeopositionRepository Geopositions { get; private set; }

        public IMessageRepository Messages { get; private set; }

        public IPestRepository Pests { get; private set; }

        public IPhotoRepository Photos { get; private set; }

        public IPlantRepository Plants { get; private set; }

        public ISoilReadingRepository SoilReadings { get; private set; }

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
