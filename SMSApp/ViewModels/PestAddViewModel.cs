using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class PestAddViewModel : EntityAddViewModel<Pest>
    {

        public PestAddViewModel(IContainer container, IUnitOfWork unitOfWork, Pest model, bool isUpdate=false) : base(container, isUpdate, unitOfWork, model)
        {
        }
    }
}
