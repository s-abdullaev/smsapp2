using SMSApp.Enums;
using SMSApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SMSApp.Views
{
    public partial class SeasonAddView : Window
    {

        public SeasonAddView(SeasonAddViewModel viewModel)
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
            cbxSeasons.ItemsSource = Enum.GetValues(typeof(SeasonTimes)).Cast<SeasonTimes>();
            cbxGrowthStatus.ItemsSource = Enum.GetValues(typeof(PlantGrowthStatus)).Cast<PlantGrowthStatus>();
        }
    }
}
