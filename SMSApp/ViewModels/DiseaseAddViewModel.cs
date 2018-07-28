using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class DiseaseAddViewModel : EntityAddViewModel<Disease>
    {
        public DiseaseAddViewModel(IContainer container, IUnitOfWork unitOfWork, Disease model, bool isUpdate=false) : base(container, isUpdate, unitOfWork, model)
        {
        }
    }
}
