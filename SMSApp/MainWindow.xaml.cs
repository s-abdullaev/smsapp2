using System.Windows;
using SMSApp.DataAccess;
using SMSApp.Repositories;

using SMSApp.ViewModels;

namespace SMSApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}