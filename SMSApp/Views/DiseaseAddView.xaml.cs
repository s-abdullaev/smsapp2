using SMSApp.Enums;
using System;
using System.Linq;
using System.Windows;

namespace SMSApp.Views
{
    /// <summary>
    /// Interaction logic for DiseaseAddView.xaml
    /// </summary>
    public partial class DiseaseAddView : Window
    {
        public DiseaseAddView(ViewModels.DiseaseAddViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.CloseAction = new Action(this.Close);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxDangerRating.ItemsSource = Enum.GetValues(typeof(DangerRating)).Cast<DangerRating>();
        }
    
    }
}
