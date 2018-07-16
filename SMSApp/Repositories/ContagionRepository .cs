using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class ContagionRepository : Repository<Contagion>, IContagionRepository
    {
        public ContagionRepository(Context dbContext)
            : base(dbContext)
        {

        }

    }
}
