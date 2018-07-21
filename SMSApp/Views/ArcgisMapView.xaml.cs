using SMSApp.ViewModels;
using System.Windows;


namespace SMSApp.Views
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class ArcgisMapView : Window
    {
        public ArcgisMapView()
        {
            InitializeComponent();
            this.DataContext = new ArcgisMapViewModel(MyMapView);
        }
    }
}
