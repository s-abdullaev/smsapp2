using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class PlantRepository : Repository<Plant>, IPlantRepository
    {
        public PlantRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

    }
}
