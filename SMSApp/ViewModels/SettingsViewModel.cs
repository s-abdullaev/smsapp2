
using Autofac;
using Microsoft.Win32;
using Prism.Commands;
using SMSApp.Helpers;
using System.Windows.Input;

namespace SMSApp.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(IContainer container) : base(container)
        {
        }

        public string CheckSMS
        {
            get => USSDHelper.GetPropertyFromRegistry("CheckSMS");
            set => USSDHelper.SetPropertyInRegistry("CheckSMS", value); 
        }

        public string BuySMS
        {
            get => USSDHelper.GetPropertyFromRegistry("BuySMS");
            set => USSDHelper.SetPropertyInRegistry("BuySMS", value);
        }

    }
}
