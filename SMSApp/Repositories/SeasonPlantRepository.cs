using SMSApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Repositories.Core
{
    public class SeasonPlantRepository:Repository<SeasonPlant>, ISeasonPlantRepository
    {
        public SeasonPlantRepository(Context dbContext):base(dbContext)
        {

        }

        public void AddSeasonPlants(Season s, IEnumerable<Plant> plants)
        {
            foreach(var p in plants)
            {
                var sp = new SeasonPlant();
                sp.Season = s;
                sp.Plant = p;
                s.Plants.Add(sp);
            }
        }

        public void ClearSeasonPlants(Season s)
        {

            s.Plants.Clear();
            //foreach (var sp in s.Plants)
            //{
            //    Remove(sp);
            //}
        }
    }
}
