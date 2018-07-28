using SMSApp.ViewModels;
using System.Windows;

namespace SMSApp.Views
{
    public partial class FarmOwnerManagerView : Window
    {
        public FarmOwnerManagerView(FarmOwnerManagerViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
