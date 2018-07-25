using System.Windows;

namespace SMSApp.Services
{
    public class AlertsService
    {
        const string DISPLAY_APP_NAME = "Farm SMS App";

        public void ShowInfoMsg(string msg)
        {
            MessageBox.Show(msg, DISPLAY_APP_NAME, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowWarningMsg(string msg)
        {
            MessageBox.Show(msg, DISPLAY_APP_NAME, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ShowErrorMsg(string msg)
        {
            MessageBox.Show(msg, DISPLAY_APP_NAME, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public MessageBoxResult ShowQuestionYesNoMsg(string msg)
        {
            return MessageBox.Show(msg, DISPLAY_APP_NAME, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }

    }
}
