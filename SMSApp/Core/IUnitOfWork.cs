using SMSApp.Core.Repositories;
using System;

namespace SMSApp
{
    public interface IUnitOfWork:IDisposable
    {
        int Complete();
        IUserRepository Users { get; }
    }
}
