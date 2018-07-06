using SMSApp.ViewModels;
using System.Windows.Controls;

namespace SMSApp.Views
{
    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
            DataContext = new MapViewModel(MapView);
        }
    }
}
