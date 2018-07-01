using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class PestRepository : Repository<Pest>, IPestRepository
    {
        public PestRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

    }
}
