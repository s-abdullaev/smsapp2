using Autofac;
using SMSApp.ExtensionMethods;

namespace SMSApp.ViewModels
{
    public class BroadcastSettingsViewModel : ViewModelBase
    {
        public BroadcastSettingsViewModel(IContainer container) : base(container)
        {
        }

        public string CheckSMS
        {
            get => "CheckSMS".GetPropertyFromRegistry();
            set => "CheckSMS".SetPropertyInRegistry(value); 
        }

        public string BuySMS
        {
            get => "BuySMS".GetPropertyFromRegistry();
            set => "BuySMS".SetPropertyInRegistry(value);
        }

    }
}
