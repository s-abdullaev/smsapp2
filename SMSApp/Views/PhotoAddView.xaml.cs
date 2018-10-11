using SMSApp.ViewModels;
using System.Windows;

namespace SMSApp.Views
{
    /// <summary>
    /// Interaction logic for PhotoAddView.xaml
    /// </summary>
    public partial class PhotoAddView : Window
    {
        public PhotoAddView(PhotoAddViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
