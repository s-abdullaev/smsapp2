using SMSApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SMSApp.Controls.MapControl
{
    public partial class MapControlView : UserControl
    {
        public MapControlView()
        {
            InitializeComponent();
            this.DataContext = new MapControlViewModel(MyMapView);
        }
    }
}
