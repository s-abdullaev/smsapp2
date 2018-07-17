using System;
using System.Windows;
using SMSApp.ViewModels;

namespace SMSApp.Views
{
    public partial class UserAddView : Window
    {
        public UserAddView(UserAddViewModel viewModel)
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