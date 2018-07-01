using System.Windows;

using SMSApp.ViewModels;

namespace SMSApp.Views
{
    public partial class UserAddFormView : Window
    {
        public UserAddFormView()
        {
            InitializeComponent();
            DataContext = new UserAddFormViewModel(this);
        }
    }
}