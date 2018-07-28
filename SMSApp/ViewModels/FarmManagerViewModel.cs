using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using SMSApp.Views;

namespace SMSApp.ViewModels
{
    public class FarmManagerViewModel : EntityManagerViewModel<Farm>
    {
        public FarmManagerViewModel(IContainer container, IUnitOfWork unitOfWork) : base(container, unitOfWork)
        {
        }

        public override void ExecuteOpenAddItemCommand()
        {
            FarmAddView view = _container.Resolve<FarmAddView>();
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }

        public override void ExecuteEditAddItemCommand()
        {
            FarmAddView view = _container.Resolve<FarmAddView>(
                new NamedParameter("viewModel", _container.Resolve<FarmAddViewModel>(
                    new NamedParameter("model", SelectedItem),
                    new NamedParameter("isUpdate", true)
                )));
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }
    }
}
