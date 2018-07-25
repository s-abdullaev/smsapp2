using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.ViewModels
{
    public class DiseaseManagerViewModel : EntityManagerViewModel<Disease>
    {
        public DiseaseManagerViewModel(IContainer container, IUnitOfWork unitOfWork) : base(container, unitOfWork)
        {
        }
    }
}
