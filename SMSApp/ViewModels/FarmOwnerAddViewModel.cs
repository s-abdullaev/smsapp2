using Autofac;
using Prism.Commands;
using SMSApp.Controls.FilePicker;
using SMSApp.DataAccess;
using SMSApp.ExtensionMethods;
using SMSApp.Repositories.Core;
using SMSApp.Views;

namespace SMSApp.ViewModels
{
    public class FarmOwnerAddViewModel : EntityAddViewModel<FarmOwner>
    {
      
        public FarmOwnerAddViewModel(IContainer container, IUnitOfWork unitOfWork, FarmOwner model, bool isUpdate = false) : base(container, isUpdate, unitOfWork, model)
        {
        }

    }
}
