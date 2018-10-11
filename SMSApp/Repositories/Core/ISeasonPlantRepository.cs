using SMSApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Repositories.Core
{
    public interface ISeasonPlantRepository:IRepository<SeasonPlant>
    {
        void ClearSeasonPlants(Season s);
        void AddSeasonPlants(Season s, IEnumerable<Plant> plants);
    }
}
