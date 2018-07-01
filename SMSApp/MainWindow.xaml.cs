using System.Windows;

using SMSApp.Views;

namespace SMSApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserAddFormView view = new UserAddFormView();
            view.ShowDialog();
        }
    }
}