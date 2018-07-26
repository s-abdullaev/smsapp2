using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class PlantAddViewModel : EntityAddViewModel<Plant>
    {
        public PlantAddViewModel(IContainer container, IUnitOfWork unitOfWork, Plant model, bool isUpdate=false) : base(container, isUpdate, unitOfWork, model)
        {
        }
    }
}
