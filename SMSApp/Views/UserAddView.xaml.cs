using System.Windows;

using SMSApp.ViewModels;

namespace SMSApp.Views
{
    public partial class UserAddView : Window
    {
        public UserAddView()
        {
            InitializeComponent();
            DataContext = new UserAddViewModel(this);
        }
    }
}