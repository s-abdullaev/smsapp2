using Autofac;

namespace SMSApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public FarmOwnerManagerViewModel FarmOwnerVwMdl { get; }
        public PlantManagerViewModel PlantVwMdl { get; }

        public MainWindowViewModel(IContainer container) : base(container)
        {
            FarmOwnerVwMdl = container.Resolve<FarmOwnerManagerViewModel>();
            PlantVwMdl = container.Resolve<PlantManagerViewModel>();
        }

        
    }
}
