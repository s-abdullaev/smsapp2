using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class FarmPlantRepository : Repository<FarmPlant>, IFarmPlantRepository
    {
        public FarmPlantRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

    }
}
