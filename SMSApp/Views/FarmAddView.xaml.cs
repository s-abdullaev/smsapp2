using SMSApp.ViewModels;
using System;
using System.Windows;

namespace SMSApp.Views
{
    /// <summary>
    /// Interaction logic for FarmAddView.xaml
    /// </summary>
    public partial class FarmAddView : Window
    {
        public FarmAddView(FarmAddViewModel viewModel)
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
