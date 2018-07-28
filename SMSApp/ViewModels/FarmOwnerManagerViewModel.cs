using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using SMSApp.Views;

namespace SMSApp.ViewModels
{
    public class FarmOwnerManagerViewModel : EntityManagerViewModel<FarmOwner>
    {
        public FarmOwnerManagerViewModel(IContainer container, IUnitOfWork unitOfWork) : base(container, unitOfWork)
        {
        }

        public override void ExecuteOpenAddItemCommand()
        {
            FarmOwnerAddView view = _container.Resolve<FarmOwnerAddView>();
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }

        public override void ExecuteEditAddItemCommand()
        {
            FarmOwnerAddView view = _container.Resolve<FarmOwnerAddView>(
                new NamedParameter("viewModel", _container.Resolve<FarmOwnerAddViewModel>(
                    new NamedParameter("model", SelectedItem),
                    new NamedParameter("isUpdate", true)
                )));
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }
    }
}
