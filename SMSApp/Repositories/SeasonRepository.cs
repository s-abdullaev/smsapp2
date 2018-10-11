using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Repositories
{
    public class SeasonRepository:Repository<Season>,ISeasonRepository
    {
        public SeasonRepository(Context dbContext):base(dbContext)
        {

        }


    }
}
