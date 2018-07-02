using System.Windows;

using SMSApp.ViewModels;

namespace SMSApp.Views
{
    public partial class UserManagerView : Window
    {
        public UserManagerView()
        {
            InitializeComponent();
            DataContext = new UserManagerViewModel();
        }
    }
}
