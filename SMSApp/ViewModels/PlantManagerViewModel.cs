using Autofac;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using SMSApp.Views;

namespace SMSApp.ViewModels
{
    public class PlantManagerViewModel : EntityManagerViewModel<Plant>
    {
        public PlantManagerViewModel(IContainer container, IUnitOfWork unitOfWork) : base(container, unitOfWork)
        {
        }
        public override void ExecuteOpenAddItemCommand()
        {
            PlantAddView view = _container.Resolve<PlantAddView>();
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }

        public override void ExecuteEditAddItemCommand()
        {
            PlantAddView view = _container.Resolve<PlantAddView>(
                new NamedParameter("viewModel", _container.Resolve<PlantAddViewModel>(
                    new NamedParameter("model", SelectedItem),
                    new NamedParameter("isUpdate", true)
                )));
            view.ShowDialog();
            RaisePropertyChanged("Items");
        }
    }
}
