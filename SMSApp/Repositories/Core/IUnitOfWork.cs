using System;

namespace SMSApp.Repositories.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        IBroadcastRepository Broadcasts { get; }
        IContagionRepository Contagions { get; }
        IDiseaseRepository Diseases { get; }
        IFarmRepository Farms { get; }
        IFarmOwnerRepository FarmOwners { get; }
        IGeopositionRepository Geopositions { get; }
        IMessageRepository Messages { get; }
        IPestRepository Pests { get; }
        IPhotoRepository Photos { get; }
        IPlantRepository Plants { get; }
        ISoilReadingRepository SoilReadings { get; }
        IUserRepository Users { get; }
        ISeasonRepository Seasons { get; }
        ISeasonPlantRepository SeasonPlants { get; }

        IRepository<T> GetRepository<T>(string repoName) where T : class;
    }
}
