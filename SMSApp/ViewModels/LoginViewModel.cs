using Autofac;
using Prism.Commands;
using Prism.Events;
using SMSApp.Events;
using SMSApp.Repositories.Core;
using SMSApp.Services;
using System.Windows.Controls;

namespace SMSApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private IUnitOfWork uw;
        private AlertsService alertsSvc;
        public LoginViewModel(IContainer container, IUnitOfWork unitOfWork, AlertsService alSvc) : base(container)
        {
            uw = unitOfWork;
            alertsSvc = alSvc;
            LoginCmd = new DelegateCommand<PasswordBox>(ExecuteLoginCmd);
        }

        private void ExecuteLoginCmd(PasswordBox pbox)
        {
                
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<PasswordBox> LoginCmd { get; set; }

    }
}
