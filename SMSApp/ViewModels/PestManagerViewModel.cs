using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using SMSApp.Views;

namespace SMSApp.ViewModels
{
    public class PestManagerViewModel : EntityManagerViewModel<Pest>
    {
        public PestManagerViewModel(IContainer container, IUnitOfWork unitOfWork) : base(container, unitOfWork)
        {
        }

        public override void ExecuteEditAddItemCommand()
        {
            PestAddView view = _container.Resolve<PestAddView>(
                 new NamedParameter("viewModel", _container.Resolve<PestAddViewModel>(
                     new NamedParameter("model", SelectedItem),
                     new NamedParameter("isUpdate", true)
                 )));
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }

        public override void ExecuteOpenAddItemCommand()
        {
            PestAddView view = _container.Resolve<PestAddView>();
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }
    }
}
