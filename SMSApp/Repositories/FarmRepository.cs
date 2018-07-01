using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class FarmRepository : Repository<Farm>, IFarmRepository
    {
        public FarmRepository(Context dbContext)
            : base(dbContext)
        {

        }

    }
}
