using Prism.Mvvm;
using Prism.Commands;

using SMSApp.Views;

namespace SMSApp.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            OpenUserManagerCommand = new DelegateCommand(ExecuteOpenUserManagerCommand);
            OpenFarmOwnerManagerCommand = new DelegateCommand(ExecuteOpenFarmOwnerManagerCommand);
            OpenFarmManagerCommand = new DelegateCommand(ExecuteOpenFarmManagerCommand);
            OpenPlantManagerCommand = new DelegateCommand(ExecuteOpenPlantManagerCommand);
            OpenDiseaseManagerCommand = new DelegateCommand(ExecuteOpenDiseaseManagerCommand);
            OpenPestManagerCommand = new DelegateCommand(ExecuteOpenPestManagerCommand);
        }

        public DelegateCommand OpenUserManagerCommand { get; private set; }
        private void ExecuteOpenUserManagerCommand()
        {
            UserManagerView view = new UserManagerView();
            view.ShowDialog();
        }

        public DelegateCommand OpenFarmOwnerManagerCommand { get; private set; }
        private void ExecuteOpenFarmOwnerManagerCommand()
        {
            FarmOwnerManagerView view = new FarmOwnerManagerView();
            view.ShowDialog();
        }

        public DelegateCommand OpenFarmManagerCommand { get; private set; }
        private void ExecuteOpenFarmManagerCommand()
        {
            FarmManagerView view = new FarmManagerView();
            view.ShowDialog();
        }

        public DelegateCommand OpenPlantManagerCommand { get; private set; }
        private void ExecuteOpenPlantManagerCommand()
        {
            PlantManagerView view = new PlantManagerView();
            view.ShowDialog();
        }

        public DelegateCommand OpenDiseaseManagerCommand { get; private set; }
        private void ExecuteOpenDiseaseManagerCommand()
        {
            DiseaseManagerView view = new DiseaseManagerView();
            view.ShowDialog();
        }

        public DelegateCommand OpenPestManagerCommand { get; private set; }
        private void ExecuteOpenPestManagerCommand()
        {
            PestManagerView view = new PestManagerView();
            view.ShowDialog();
        }
    }
}
