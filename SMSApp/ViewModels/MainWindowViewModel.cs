using Autofac;

namespace SMSApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IContainer container, NavigationMenuViewModel navVwMdl) : base(container)
        {
            NavVwMdl = navVwMdl;
        }

        public NavigationMenuViewModel NavVwMdl { get; }
    }
}
