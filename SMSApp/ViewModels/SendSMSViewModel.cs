using Autofac;
using Prism.Commands;
using HeadwindGSM;

namespace SMSApp.ViewModels
{
    public class SendSMSViewModel : ViewModelBase
    {
        
        public string SendTo
        {
            get { return _smsMsg.To; }
            set { _smsMsg.To = value; RaisePropertyChanged(); }
        }


        public string Message
        {
            get { return _smsMsg.Body; }
            set { _smsMsg.Body = value; RaisePropertyChanged(); }
        }

        private SMSMessage _smsMsg;

        public DelegateCommand SendSMSCommand { get; set; }

        public SendSMSViewModel(IContainer container, SMSMessage smsMsg) : base(container)
        {
            _smsMsg = smsMsg;
            SendSMSCommand = new DelegateCommand(ExecuteSendSMS);
        }

        public void ExecuteSendSMS()
        {
            _smsMsg.Send();
        }
    }
}
