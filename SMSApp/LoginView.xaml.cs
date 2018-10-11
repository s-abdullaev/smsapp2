using SMSApp.Repositories.Core;
using SMSApp.Services;
using System.ComponentModel;
using System.Windows;

namespace SMSApp
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {

        private IUnitOfWork uw;
        private AlertsService alSvc;
        public LoginView(IUnitOfWork unitOfWork, AlertsService alertSvc)
        {
            InitializeComponent();
            uw = unitOfWork;
            alSvc = alertSvc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (uw.Users.AuthUser(txtLogin.Text, txtPassword.Password))
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                alSvc.ShowWarningMsg("Your login credentials are invalid");
            }
        }
    }
}
