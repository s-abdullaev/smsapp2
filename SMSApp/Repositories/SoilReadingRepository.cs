using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class SoilReadingRepository : Repository<SoilReading>, ISoilReadingRepository
    {
        public SoilReadingRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

    }
}
