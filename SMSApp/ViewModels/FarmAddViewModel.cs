using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class FarmAddViewModel : EntityAddViewModel<Farm>
    {
        public FarmAddViewModel(IContainer container, IUnitOfWork unitOfWork, Farm model, bool isUpdate=false) : base(container, isUpdate, unitOfWork, model)
        {
        }
    }
}
