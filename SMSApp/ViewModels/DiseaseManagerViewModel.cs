using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using SMSApp.Views;

namespace SMSApp.ViewModels
{
    public class DiseaseManagerViewModel : EntityManagerViewModel<Disease>
    {
        public DiseaseManagerViewModel(IContainer container, IUnitOfWork unitOfWork) : base(container, unitOfWork)
        {
        }

        public override void ExecuteEditAddItemCommand()
        {
            DiseaseAddView view = _container.Resolve<DiseaseAddView>();
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }

        public override void ExecuteOpenAddItemCommand()
        {
            DiseaseAddView view = _container.Resolve<DiseaseAddView>(
                new NamedParameter("viewModel", _container.Resolve<DiseaseAddView>(
                    new NamedParameter("userModel", SelectedItem),
                    new NamedParameter("isUpdate", true)
                )));
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }
    }
}
