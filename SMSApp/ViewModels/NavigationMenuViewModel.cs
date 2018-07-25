using Prism.Commands;
using SMSApp.Views;
using Autofac;
using SMSApp.Services;

namespace SMSApp.ViewModels
{
    public class NavigationMenuViewModel : ViewModelBase
    {
        public NavigationMenuViewModel(IContainer container, AlertsService alertsService, SMSService smsService) : base(container)
        {

            _alertSvc = alertsService;
            _smsSvc = smsService;

            OpenUserManagerCommand = new DelegateCommand(ExecuteOpenUserManagerCommand);
            OpenFarmOwnerManagerCommand = new DelegateCommand(ExecuteOpenFarmOwnerManagerCommand);
            OpenFarmManagerCommand = new DelegateCommand(ExecuteOpenFarmManagerCommand);
            OpenPlantManagerCommand = new DelegateCommand(ExecuteOpenPlantManagerCommand);
            OpenDiseaseManagerCommand = new DelegateCommand(ExecuteOpenDiseaseManagerCommand);
            OpenPestManagerCommand = new DelegateCommand(ExecuteOpenPestManagerCommand);
            OpenSendSMSCommand = new DelegateCommand(ExecuteOpenSendSMSCommand);
            OpenSMSSettingsCommand = new DelegateCommand(ExecuteOpenSMSSettingsCommand);
            OpenBroadcastCommand = new DelegateCommand(ExecuteOpenBroadcastCommand);

            BuySMSCommand = new DelegateCommand(ExecuteBuySMSCommand, () => !IsUSSDSending);
            CheckSMSCommand = new DelegateCommand(ExecuteCheckSMSCommand, () => !IsUSSDSending);
        }

        private AlertsService _alertSvc;
        private SMSService _smsSvc;

        private bool _isUSSDSending;

        public bool IsUSSDSending
        {
            get { return _isUSSDSending; }
            set
            {
                _isUSSDSending = value;
                RaisePropertyChanged();
                BuySMSCommand.RaiseCanExecuteChanged();
                CheckSMSCommand.RaiseCanExecuteChanged();
            }
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

        public DelegateCommand OpenBroadcastCommand { get; private set; }
        private void ExecuteOpenBroadcastCommand()
        {
            var view = _container.Resolve<BroadcastManagerView>();
            view.ShowDialog();
        }

        public DelegateCommand BuySMSCommand { get; private set; }
        private async void ExecuteBuySMSCommand()
        {

            IsUSSDSending = true;
            _alertSvc.ShowInfoMsg(await _smsSvc.SendBuySMS());
            IsUSSDSending = false;
        }

        public DelegateCommand CheckSMSCommand { get; private set; }
        private async void ExecuteCheckSMSCommand()
        {
            IsUSSDSending = true;
            _alertSvc.ShowInfoMsg(await _smsSvc.SendCheckSMS());
            IsUSSDSending = false;
        }
    }
}
