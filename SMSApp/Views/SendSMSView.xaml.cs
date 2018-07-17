using SMSApp.ViewModels;
using System.Windows;

namespace SMSApp.Views
{
    /// <summary>
    /// Interaction logic for SendSMSView.xaml
    /// </summary>
    public partial class SendSMSView : Window
    {
        public SendSMSView(SendSMSViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
