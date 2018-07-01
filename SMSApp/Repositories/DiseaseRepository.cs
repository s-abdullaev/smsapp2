using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class DiseaseRepository : Repository<Disease>, IDiseaseRepository
    {
        public DiseaseRepository(Context dbContext)
            : base(dbContext)
        {

        }

    }
}
