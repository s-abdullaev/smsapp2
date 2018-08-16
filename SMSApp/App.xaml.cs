using Autofac;
using Prism.Events;
using SMSApp.Events;
using SMSApp.Repositories.Core;
using SMSApp.Startup;
using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace SMSApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            StyleManager.ApplicationTheme = new Office2016Theme();

            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();
            var mainWindow = container.Resolve<MainWindow>();
            
            mainWindow.Show();

#if !DEBUG
            mainWindow.IsEnabled = false;

            var loginWindow = container.Resolve<LoginView>();
            loginWindow.ShowDialog();
            if (loginWindow.DialogResult == true)
            {
                mainWindow.IsEnabled = true;
            }
            else
            {
                mainWindow.Close();
            };
#else
            var uw = container.Resolve<IUnitOfWork>();
                uw.Users.AuthUser("user_1", "password");
#endif    
        }


        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unexpected error occured. Please, inform the admin." + Environment.NewLine + e.Exception.Message, "Unexpected Error");
            e.Handled = true;
        }
    }
}
