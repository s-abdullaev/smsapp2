using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class FarmOwnerAddViewModel : EntityAddViewModel<FarmOwner>
    {
        public FarmOwnerAddViewModel(IContainer container, bool isUpdate, IUnitOfWork unitOfWork, FarmOwner model) : base(container, isUpdate, unitOfWork, model)
        {
        }
    }
}
