using System;
using System.Threading.Tasks;
using HeadwindGSM;
using SMSApp.ExtensionMethods;

namespace SMSApp.Services
{
    public class SMSService
    {
        private SMSDriver driver;
        
        public SMSService()
        {
            driver = new SMSDriver();
            driver.USSDReply += ussdCallback;
        }

        private void ussdCallback(string sContent, uint nCode, string sRcpt)
        {
            sendUSSDTcs.SetResult(sContent);
        }

        public void SendSMS(string sendTo, string message)
        {
            var smsMsg = new SMSMessage() {
                To = sendTo,
                Body= message
            };

            smsMsg.Send();
        }

        private TaskCompletionSource<string> sendUSSDTcs;

        public Task<string> SendBuySMS()
        {
            sendUSSDTcs = new TaskCompletionSource<string>();

            var req = new USSDRequest();
            req.Content = "BuySMS".GetPropertyFromRegistry();
            req.SendWithReply(driver);

            return sendUSSDTcs.Task;
        }


        public Task<string> SendCheckSMS()
        {
            sendUSSDTcs = new TaskCompletionSource<string>();

            var req = new USSDRequest();
            req.Content = "CheckSMS".GetPropertyFromRegistry();
            req.SendWithReply(driver);

            return sendUSSDTcs.Task;
        }

    }
}
