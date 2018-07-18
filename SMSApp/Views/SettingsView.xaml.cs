using SMSApp.ViewModels;
using System.Windows;

namespace SMSApp.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        public SettingsView(SettingsViewModel model)
        {
            InitializeComponent();
            model.CloseAction = new System.Action(this.Close);
            this.DataContext = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
