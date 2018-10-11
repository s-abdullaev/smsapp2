using System;
using System.Windows;
using SMSApp.ViewModels;

namespace SMSApp.Views
{
    public partial class GeopositionAddView : Window
    {
        public GeopositionAddView(GeopositionAddViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            viewModel.CloseAction = new Action(this.Close);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}