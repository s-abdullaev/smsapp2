using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class DiseaseAddViewModel : EntityAddViewModel<Disease>
    {
        public DiseaseAddViewModel(IContainer container, bool isUpdate, IUnitOfWork unitOfWork, Disease model) : base(container, isUpdate, unitOfWork, model)
        {
        }
    }
}
