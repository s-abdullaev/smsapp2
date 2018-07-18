using Prism.Commands;
using SMSApp.Views;
using Autofac;
using SMSApp.Helpers;
using System.Windows;

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
            OpenSMSSettingsCommand = new DelegateCommand(ExecuteOpenSMSSettingsCommand);
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

        public DelegateCommand OpenSMSSettingsCommand { get; private set; }
        private void ExecuteOpenSMSSettingsCommand()
        {
            SettingsView view = _container.Resolve<SettingsView>();
            view.ShowDialog();
        }

        public DelegateCommand BuySMSCommand { get; private set; }
        private void ExecuteBuySMSCommand()
        {
            var observer = new HeadwindGSM.SMSDriver();
            var req = new HeadwindGSM.USSDRequest();
            req.Content = USSDHelper.GetPropertyFromRegistry("BuySMS");
            observer.USSDReply += Observer_USSDReply;
            req.SendWithReply(observer);
        }

        private void Observer_USSDReply(string sContent, uint nCode, string sRcpt)
        {
            MessageBox.Show(sContent);
        }

        public DelegateCommand CHeckSMSCommand { get; private set; }
        private void ExecuteCHeckSMSCommand()
        {
            SettingsView view = _container.Resolve<SettingsView>();
            view.ShowDialog();
        }
    }
}
