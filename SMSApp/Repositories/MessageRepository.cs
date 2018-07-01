using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(Context dbContext)
            : base(dbContext)
        {

        }

    }
}
