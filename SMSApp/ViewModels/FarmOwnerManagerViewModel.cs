using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class FarmOwnerManagerViewModel : EntityManagerViewModel<FarmOwner>
    {
        public FarmOwnerManagerViewModel(IContainer container, IUnitOfWork unitOfWork) : base(container, unitOfWork)
        {
        }
    }
}
