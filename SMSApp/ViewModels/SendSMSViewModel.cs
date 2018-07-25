using Autofac;
using Prism.Commands;
using HeadwindGSM;
using SMSApp.Services;

namespace SMSApp.ViewModels
{
    public class SendSMSViewModel : ViewModelBase
    {
        private string _sendTo;
        private string _message;
        private SMSService _smsSvc;

        public SendSMSViewModel(IContainer _container, SMSService smsSvc): base(_container)
        {
            _smsSvc = smsSvc;
        }


        public string SendTo
        {
            get { return _sendTo; }
            set {_sendTo = value; RaisePropertyChanged(); }
        }


        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(); }
        }

        public DelegateCommand SendSMSCommand { get; set; }

        public SendSMSViewModel(IContainer container) : base(container)
        {
            SendSMSCommand = new DelegateCommand(ExecuteSendSMS);
        }

        public void ExecuteSendSMS()
        {
            _smsSvc.SendSMS(SendTo, Message);
            CloseAction();
        }
    }
}
