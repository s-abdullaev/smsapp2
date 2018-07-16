using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class BroadcastRepository : Repository<Broadcast>, IBroadcastRepository
    {
        public BroadcastRepository(Context dbContext) :
            base(dbContext)
        {

        }

        

        /// <summary>
        /// Context
        /// </summary>
        public Context ApplicationContext { get => mContext as Context; }
    }
}
