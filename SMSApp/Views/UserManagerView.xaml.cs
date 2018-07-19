using System.Windows;

using SMSApp.ViewModels;

namespace SMSApp.Views
{
    public partial class UserManagerView : Window
    {
        public UserManagerView(UserManagerViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
