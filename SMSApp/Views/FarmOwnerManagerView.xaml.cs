using SMSApp.ViewModels;
using System.Windows;

namespace SMSApp.Views
{
    public partial class FarmOwnerManagerView : Window
    {
        public FarmOwnerManagerView(FarmOwnerManagerViewModel viewModel)
        {
            InitializeComponent();
<<<<<<< HEAD
            DataContext = viewModel;
=======
            this.DataContext = viewModel;
>>>>>>> bfeed3d5209ffdc796f6cd4465037fd5d1398a37
        }
    }
}
