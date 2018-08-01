using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class FarmOwnerAddViewModel : EntityAddViewModel<FarmOwner>
    {
        public FarmOwnerAddViewModel(IContainer container, IUnitOfWork unitOfWork, FarmOwner model, bool isUpdate=false) : base(container, isUpdate, unitOfWork, model)
        {
        }

        public override void ExecuteAddEntityCommand()
        {
            Model.User = uw.Users.CurrentUser();
            base.ExecuteAddEntityCommand();
        }
    }
}
