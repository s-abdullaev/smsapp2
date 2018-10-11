using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SMSApp.Views
{
    public partial class FarmOwnerAddView : Window
    {
        public FarmOwnerAddView(ViewModels.FarmOwnerAddViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            viewModel.CloseAction = new Action(this.Close);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}