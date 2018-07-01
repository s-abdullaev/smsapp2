using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class GeopositionRepository : Repository<Geoposition>, IGeopositionRepository
    {
        public GeopositionRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

    }
}
