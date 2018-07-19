using Prism.Commands;
using SMSApp.Views;
using Autofac;

namespace SMSApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IContainer container):base(container)
        {
            OpenUserManagerCommand = new DelegateCommand(ExecuteOpenUserManagerCommand);
            OpenFarmOwnerManagerCommand = new DelegateCommand(ExecuteOpenFarmOwnerManagerCommand);
            OpenFarmManagerCommand = new DelegateCommand(ExecuteOpenFarmManagerCommand);
            OpenPlantManagerCommand = new DelegateCommand(ExecuteOpenPlantManagerCommand);
            OpenDiseaseManagerCommand = new DelegateCommand(ExecuteOpenDiseaseManagerCommand);
            OpenPestManagerCommand = new DelegateCommand(ExecuteOpenPestManagerCommand);
            OpenSendSMSCommand = new DelegateCommand(ExecuteOpenSendSMSCommand);
        }

        public DelegateCommand OpenUserManagerCommand { get; private set; }
        private void ExecuteOpenUserManagerCommand()
        {
            UserManagerView view = _container.Resolve<UserManagerView>();
            view.ShowDialog();
        }

        public DelegateCommand OpenFarmOwnerManagerCommand { get; private set; }
        private void ExecuteOpenFarmOwnerManagerCommand()
        {
            FarmOwnerManagerView view = _container.Resolve<FarmOwnerManagerView>();
            view.ShowDialog();
        }

        public DelegateCommand OpenFarmManagerCommand { get; private set; }
        private void ExecuteOpenFarmManagerCommand()
        {
            FarmManagerView view = _container.Resolve<FarmManagerView>();
            view.ShowDialog();
        }

        public DelegateCommand OpenPlantManagerCommand { get; private set; }
        private void ExecuteOpenPlantManagerCommand()
        {
            PlantManagerView view = _container.Resolve<PlantManagerView>();
            view.ShowDialog();
        }

        public DelegateCommand OpenDiseaseManagerCommand { get; private set; }
        private void ExecuteOpenDiseaseManagerCommand()
        {
            DiseaseManagerView view = _container.Resolve<DiseaseManagerView>();
            view.ShowDialog();
        }

        public DelegateCommand OpenPestManagerCommand { get; private set; }
        private void ExecuteOpenPestManagerCommand()
        {
            PestManagerView view = _container.Resolve<PestManagerView>();
            view.ShowDialog();
        }

        public DelegateCommand OpenSendSMSCommand { get; private set; }
        private void ExecuteOpenSendSMSCommand()
        {
            SendSMSView view = _container.Resolve<SendSMSView>();
            view.ShowDialog();
        }
    }
}
